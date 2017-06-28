﻿using System;
using System.Windows.Forms;
using AnemoneTriz.Components;
using SkiaSharp;

namespace AnemoneTriz.Forms
{
    public partial class MainForm : Form
    {
        internal SkiaHelper SKHelper { get; set; }

        public MainForm()
        {
            InitializeComponent();
            DoubleBuffered = true;
            SKHelper = new SkiaHelper();
            SKHelper.Size = new RawSize
            {
                Width = this.Width,
                Height = this.Height
            };
            SKHelper.PostChain = new SkiaHelper.CanvasDelegate((SKCanvas Canvas) =>
            {
                var Colors = new SKColor[] { SKColors.Orange, SKColors.Orange, SKColors.Gold };
                using (var paint = new SKPaint())
                {
                    paint.IsAntialias = true;
                    using (var shader = SKShader.CreateLinearGradient(
                        new SKPoint(SKHelper.Size.Width - 200, 200),
                        new SKPoint(SKHelper.Size.Width, 0),
                        Colors,
                        null,
                        SKShaderTileMode.Clamp))
                    {
                        paint.Shader = shader;
                        SKHelper.Skia_Canvas.DrawPaint(paint);
                    }
                }
            });
            SKHelper.SwapChain();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text = $"{Properties.Resources.ResourceManager.GetString("AnemoneTitleName")} v{Properties.Resources.ResourceManager.GetString("AnemoneVersion")}";
        }

        private void ocrModeButton_Click(object sender, EventArgs e)
        {

        }
        
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            SKHelper.CopyToGraphics(e.Graphics);
            //e.Graphics.DrawImage(SKHelper.CSharp_Bitmap, this.ClientRectangle);
        }

        private void AnemoneTrizAboutMenuItem_Click(object sender, EventArgs e)
        {
            var aboutBox = new AboutForm();
            aboutBox.ShowDialog();
        }

        private void ShortTranslateMenuItem_Click(object sender, EventArgs e)
        {
            var shortTransBox = new ShortTransBox();
            shortTransBox.Show();
        }
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            SKHelper.SizeCheckAndRefresh(new RawSize(this.Width, this.Height));
            Invalidate();
        }
        
        private void TestFormMenuItem_Click(object sender, EventArgs e)
        {
            TestForm tf = new TestForm();
            tf.Show();
        }
    }
}