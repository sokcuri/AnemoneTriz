using AnemoneTriz.Frames;
using AnemoneTriz.Interop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AnemoneTriz.Interop.NativeMethods;

namespace AnemoneTriz.Forms
{
    public partial class ToolBox : Form
    {
        AnemoneFrame anemoneFrame { get; set; }
        public ToolBox(AnemoneFrame AF)
        {
            anemoneFrame = AF;
            InitializeComponent();
        }

        protected override void WndProc(ref Message message)
        {
            if ((AnemoneTriz.Interop.WM)message.Msg == WM.NCHITTEST)
            {
                // message.Result = (IntPtr)HitTestValues.HTCAPTION;
                // return;
            }

            base.WndProc(ref message);
        }
    }
}