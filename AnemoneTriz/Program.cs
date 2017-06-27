using System;
using System.Windows.Forms;
using System.Threading;
using static AnemoneTriz.Interop.NativeMethods;

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
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            else
            {
                IntPtr handle = FindWindow(null, Properties.Resources.ResourceManager.GetString("AnemoneTitleName"));
                ShowWindow(handle, 5);
                BringWindowToTop(handle);
                SetForegroundWindow(handle);
            }
        }
    }
}
