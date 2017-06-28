﻿using System;
using System.Windows.Forms;
using AnemoneTriz.Components;
using SkiaSharp;
using System.Diagnostics;
using System.Drawing;

namespace AnemoneTriz.Forms
{
    public partial class MainForm : Form
    {
        internal SkiaHelper SKHelper { get; set; }

        public MainForm()
        {
            InitializeComponent();
            DoubleBuffered = true;
            SKHelper = new SkiaHelper()
            {
                Size = new RawSize
                {
                    Width = this.Width,
                    Height = this.Height
                },
                PostChain = new SkiaHelper.CanvasDelegate((SKCanvas Canvas) =>
                {
                    using (var paint = new SKPaint())
                    using (var shader = SKShader.CreateLinearGradient(
                        new SKPoint(SKHelper.Size.Width - 200, 200),
                        new SKPoint(SKHelper.Size.Width, 0),
                        new SKColor[] { SKColors.Orange, SKColors.Orange, SKColors.Gold },
                        null,
                        SKShaderTileMode.Clamp))
                    {
                        paint.IsAntialias = true;
                        paint.Shader = shader;
                        SKHelper.Skia_Canvas.DrawPaint(paint);
                    }
                })
            };
            
            SKHelper.SwapChain();

            // Temporary Routine
            amButton1.BackColor = Color.FromArgb(100, 255, 255, 255);
            amButton1.FlatAppearance.BorderColor = Color.FromArgb(100, 255, 255, 255);
            amButton1.FlatStyle = FlatStyle.Flat;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Text = $"{Properties.Resources.ResourceManager.GetString("AnemoneTitleName")} v{Properties.Resources.ResourceManager.GetString("AnemoneVersion")}";
        }
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            SKHelper.SizeCheckAndRefresh(new RawSize(this.Width, this.Height));
            Invalidate();
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            SKHelper.CopyToGraphics(e.Graphics);
        }
        private void menuItem_aboutAnemoneTriz_Click(object sender, EventArgs e)
        {
            var aboutBox = new AboutForm();
            aboutBox.ShowDialog();
        }
        private void menuItem_shortTranslate_Click(object sender, EventArgs e)
        {
            var shortTransBox = new ShortTransBox();
            shortTransBox.Show();
        }
        private void menuItem_developTestForm_Click(object sender, EventArgs e)
        {
            TestForm tf = new TestForm();
            tf.Show();
        }
        private void menuItem_openInstallFolder_Click(object sender, EventArgs e)
        {
            Process.Start(AppDomain.CurrentDomain.BaseDirectory);
        }

        private void menuItem_openHomepageURL_Click(object sender, EventArgs e)
        {
            Process.Start(@"http://sokcuri.neko.kr/anemone");
        }

    }
}
