using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace AnemoneTriz.Forms
{
    partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }
        
        private void AboutBox_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url;
            if (e.Link.LinkData != null)
                url = e.Link.LinkData.ToString();
            else
                url = linkLabel1.Text.Substring(e.Link.Start, e.Link.Length);

            if (!url.Contains("://"))
                url = "http://" + url;

            var si = new ProcessStartInfo(url);
            Process.Start(si);
            linkLabel1.LinkVisited = true;
        }

        private void AboutForm_Activated(object sender, EventArgs e)
        {
            closeButton.Focus();
        }

        private void closeButton_Leave(object sender, EventArgs e)
        {
            closeButton.Focus();
        }
    }
}
