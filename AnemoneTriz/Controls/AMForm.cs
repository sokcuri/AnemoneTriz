using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AnemoneTriz.Interop.NativeMethods;

namespace AnemoneTriz.Controls
{
    public class AMForm : Form
    {
        private bool DPIAware { get; set; } = false;
        private uint PreviousDPI { get; set; } = 96;

        public AMForm() : base()
        {

        }
        protected override void WndProc(ref Message message)
        {
            if (this.IsHandleCreated == true &&
                this.DPIAware == true && 
                message.Msg == 0x02E0) // WM_DPICHANGED
            {
                uint uDpi = 96;
                DPI_AWARENESS dpiAwareness = GetAwarenessFromDpiAwarenessContext(GetThreadDpiAwarenessContext());
                switch (dpiAwareness)
                {
                    case DPI_AWARENESS.SystemAware:
                        uDpi = GetDpiForSystem();
                        break;

                    case DPI_AWARENESS.PerMonitorAware:
                        uDpi = GetDpiForWindow(this.Handle);
                        break;
                }
                
                this.Font = new Font(this.Font.FontFamily, ((float)uDpi / PreviousDPI) * this.Font.Size, this.Font.Style);

                // incompleted
                foreach(var control in this.Controls)
                {
                    if (control is Label)
                    {
                        var ctrl = control as Control;
                        if (ctrl.Font != null)
                        {
                            ctrl.Font = new Font(ctrl.Font.FontFamily, ((float)uDpi / PreviousDPI) * ctrl.Font.Size, ctrl.Font.Style);
                        }
                    }
                }

                // save previous dpi
                PreviousDPI = uDpi;
                return;
            }
            base.WndProc(ref message);
        }
    }
}
