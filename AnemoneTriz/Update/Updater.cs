using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnemoneTriz
{
    static class Updater
    {
        public static void UpdateProcess(string[] args)
        {
            if (args[0] != "--updating")
                return;

            Dictionary<string, string> dic = new Dictionary<string, string>();
            foreach (var arg in args)
            {
                if (arg.IndexOf("--") == -1 || arg.Length <= 2)
                    continue;

                try
                {
                    var items = arg.Split(':');
                    dic.Add(items[0].Substring(2), Encoding.UTF8.GetString(Convert.FromBase64String(items[1])));
                }
                catch { }
            }

            string[] requiredArguments =
            {
                "olderVersion",
                "newerVersion",
                "BaseDirectory",
                "CurrentDirectory",
                "PID",
                "ExePath",
                "AppPath"
            };
            foreach (var arg in requiredArguments)
            {
                bool check = false;
                foreach (var s in dic)
                {
                    if (arg == s.Key)
                    {
                        check = true;
                        break;
                    }
                }
                if (check == false)
                {
                    MessageBox.Show("업데이트에 필요한 필수 파라메터가 누락되었습니다.", "업데이트 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            int pid = Convert.ToInt32(dic["PID"]);

            // 10초동안 프로세스를 기다려준다
            for (int i = 0; i <= 10; i++)
            {
                // 프로세스가 죽어있음
                if (!Process.GetProcesses().Any(x => x.Id == pid))
                {
                    break;
                }
                Task.Delay(1000).Wait();

                // 3초가 지나면 업데이트를 위해 강제 종료
                if (i == 3)
                {
                    Process.GetProcessById(pid).Kill();
                }
            }

            Task.Delay(500).Wait();
            try
            {
                File.Move(dic["ExePath"], dic["ExePath"] + ".old");
            }
            catch (Exception e)
            {
                MessageBox.Show("업데이트가 실패했습니다. 파일을 옮길 수 없습니다.\r\n" + e.Message);
                return;
            }

            try
            {
                File.Move(Application.ExecutablePath, dic["ExePath"]);
            }
            catch (Exception e)
            {
                MessageBox.Show("업데이트가 실패했습니다. 파일을 옮길 수 없습니다.\r\n" + e.Message);
                return;
            }

            try
            {
                File.Delete(dic["ExePath"] + ".old");
            }
            catch (Exception e)
            {
                // 파일 삭제 실패. 하지만 그대로 진행 가능
            }

            //foreach (var s in dic)
            //MessageBox.Show(String.Format("{0}={1}", s.Key, s.Value));

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.UseShellExecute = false;
            startInfo.WorkingDirectory = dic["CurrentDirectory"];
            startInfo.FileName = dic["ExePath"];
            startInfo.Verb = "runas";
            startInfo.Arguments = "--updated";
            
            try
            {
                Process p = Process.Start(startInfo);
                Application.Exit();
            }
            catch (Win32Exception)
            {
                MessageBox.Show("재시작을 실패했습니다. 프로그램이 종료됩니다.");
                return;
            }
        }
    }
}