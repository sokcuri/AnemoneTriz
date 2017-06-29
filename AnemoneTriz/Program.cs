using System;
using System.Windows.Forms;
using System.Threading;
using AnemoneTriz.Forms;
using static AnemoneTriz.Interop.NativeMethods;
using System.Reflection;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using AnemoneTriz.Update;

namespace AnemoneTriz
{
    static class Program
    {
        private static Mutex mutex;
        
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                // 업데이트를 하기 위해 UAC 권한으로 넘어온 케이스
                if (args[0] == "--update")
                {
                    UpdateCheck.ForceRun = true;
                    UpdateCheck.CreateUpdateWindow();
                }

                // 파일 처리를 하기 위해 업데이트된 파일로 임시 실행
                if (args[0] == "--updating")
                {
                    Updater.UpdateProcess(args);
                    return;
                }

                // 업데이트 완료
                if (args[0] == "--updated")
                {
                    // 업데이트 폴더 삭제
                    UpdateCheck.CleanFolder();
                    MessageBox.Show("업데이트 되었습니다", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            else
            {
                // 업데이트 확인
                UpdateCheck.CheckUpdateAvaliable((UpdateCheck.UpdateState updateState) =>
                {
                    switch(updateState)
                    {
                        case UpdateCheck.UpdateState.UPDATE_AVALIABLE:
                            UpdateCheck.CreateUpdateWindow();
                            break;
                    }
                });
            }


            

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

                // 뮤텍스 닫기
                mutex.Close();
                
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

                // 프로세스를 강제로 죽인다
                // 강제로 죽이는 이유는, FreeLibrary를 하면서 Skia쪽의 포인터가 날아갔기 때문에
                // Main 함수가 끝나고 AccessViolation 예외가 발생하기 때문이다.
                Process.GetCurrentProcess().Kill();
            }
            else
            {
                // 아네모네 인스턴스가 이미 있는 경우 존재하는 인스턴스 윈도우를 활성화합니다
                System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
                FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
                IntPtr handle = FindWindow(null, $"{Properties.Resources.ResourceManager.GetString("AnemoneTitleName")} v{fvi.FileVersion}");
                ShowWindow(handle, 5);
                BringWindowToTop(handle);
                SetForegroundWindow(handle);
            }
        }
    }
}
