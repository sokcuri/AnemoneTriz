using AnemoneTriz.Controls;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static AnemoneTriz.Interop.NativeMethods;

namespace AnemoneTriz.Forms
{
    public partial class ShortTransBox : Form
    {
        public void SetPadding(Control textBox, Padding padding)
        {
            const int EM_SETRECT = 0xB3;
            var rect = new Rectangle(padding.Left, padding.Top, textBox.ClientSize.Width - padding.Left - padding.Right, textBox.ClientSize.Height - padding.Top - padding.Bottom);
            RECT rc = new RECT(rect);
            SendMessageRefRect(textBox.Handle, EM_SETRECT, 0, ref rc);
        }

        public ShortTransBox()
        {
            InitializeComponent();
            SetPadding(srcTextBox, new Padding(5, 5, 5, 5));
            SetPadding(destTextBox, new Padding(5, 5, 5, 5));
        }

        private void ShortTransBox_Shown(object sender, EventArgs e)
        {
        }

        private void langSwapButton_Click(object sender, EventArgs e)
        {
            var srcText = srcTextBox.Text;
            srcTextBox.Text = destTextBox.Text;
            destTextBox.Text = srcText;

            srcTextBox.Focus();
        }
    }
}
