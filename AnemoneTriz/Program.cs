using System;
using System.Windows.Forms;
using System.Threading;
using AnemoneTriz.Forms;
using static AnemoneTriz.Interop.NativeMethods;
using System.Reflection;
using System.Collections.Generic;
using System.IO;

namespace AnemoneTriz
{
    static class Program
    {
        private static Mutex mutex;
        
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool created = false;
            mutex = new Mutex(true, "AnemoneTrizMutex", out created);
            if (created)
            {
                // 임시 폴더 이름을 위한 Guid 생성 및 가공
                Guid g = Guid.NewGuid();
                string GuidString = Convert.ToBase64String(g.ToByteArray());
                GuidString = GuidString.Replace("=", "");
                GuidString = GuidString.Replace("+", "");
                var tempFolder = $"{Path.GetTempPath()}{GuidString}\\";

                // 임시 폴더 생성
                try
                {
                    Directory.CreateDirectory(tempFolder);
                }
                catch
                {
                    MessageBox.Show("임시 폴더를 만들 수 없습니다", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
                // 리소스에서 libSkiaSharp.dll 추출
                File.WriteAllBytes($"{tempFolder}libSkiaSharp.dll", Properties.Resources.libSkiaSharp);

                // libSkiaSharp를 LoadLibrary
                IntPtr dllHandle = LoadLibrary($"{tempFolder}libSkiaSharp.dll");

                // 폼 시작
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());

                // SkiaSharp.dll이 libSkiaSharp.dll을 Load했을 경우 Reference Count가 올라가므로
                // Ref.Count가 0이 될때까지 FreeLibrary 시도
                while(true)
                {
                    FreeLibrary(dllHandle);
                    if (GetModuleHandle($"{tempFolder}libSkiaSharp.dll") == IntPtr.Zero)
                    {
                        break;
                    }
                }

                // 임시 폴더를 삭제합니다. 예외가 발생할 수 있으므로 try-catch로 묶어둡니다
                try
                {
                    File.Delete($"{tempFolder}libSkiaSharp.dll");

                    System.IO.DirectoryInfo di = new DirectoryInfo(tempFolder);
                    foreach (FileInfo file in di.GetFiles())
                    {
                        file.Delete();
                    }
                    foreach (DirectoryInfo dir in di.GetDirectories())
                    {
                        dir.Delete(true);
                    }
                    Directory.Delete(tempFolder);
                }
                catch { }
            }
            else
            {
                // 아네모네 인스턴스가 이미 있는 경우 존재하는 인스턴스 윈도우를 활성화합니다
                IntPtr handle = FindWindow(null, $"{Properties.Resources.ResourceManager.GetString("AnemoneTitleName")} v{Properties.Resources.ResourceManager.GetString("AnemoneVersion")}");
                ShowWindow(handle, 5);
                BringWindowToTop(handle);
                SetForegroundWindow(handle);
            }
        }
    }
}
