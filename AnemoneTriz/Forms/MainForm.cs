using System;
using System.Windows.Forms;
using AnemoneTriz.Components;
using SkiaSharp;
using System.Diagnostics;
using System.Drawing;
using AnemoneTriz.Controls;
using AnemoneTriz.Frames;
using static AnemoneTriz.Interop.NativeMethods;
using AnemoneTriz.Properties;

namespace AnemoneTriz.Forms
{
    public partial class MainForm : AMForm
    {
        internal SkiaHelper SKHelper { get; set; }

        public MainForm()
        {
/*
            using (var g = this.CreateGraphics())
            {
                SizeF sngScaleFactor = new SizeF();
                if (g.DpiX > 96)
                {
                    sngScaleFactor.Width = g.DpiX / 96;
                    sngScaleFactor.Height = g.DpiY / 96;
                }

                if (this.AutoScaleDimensions == this.CurrentAutoScaleDimensions)
                {
                    this.Scale(sngScaleFactor);
                }
            }
  */          
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
            InitializeComponent();
            DoubleBuffered = true;
            SKHelper.SwapChain();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            Text = $"{Properties.Resources.ResourceManager.GetString("AnemoneTitleName")} v{fvi.FileVersion}";
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
            Singleton<AboutForm>.Instance.ShowDialog();
        }
        private void menuItem_shortTranslate_Click(object sender, EventArgs e)
        {
            Singleton<ShortTransBox>.Instance.Show();
            Singleton<ShortTransBox>.Instance.BringToFront();
        }
        private void menuItem_developTestForm_Click(object sender, EventArgs e)
        {
            Singleton<TestForm>.Instance.Show();
            Singleton<TestForm>.Instance.BringToFront();
        }
        private void menuItem_openInstallFolder_Click(object sender, EventArgs e)
        {
            Process.Start(AppDomain.CurrentDomain.BaseDirectory);
        }
        private void menuItem_openHomepageURL_Click(object sender, EventArgs e)
        {
            Process.Start(@"http://sokcuri.neko.kr/anemone");
        }
        
        private void gameModeButton_Click(object sender, EventArgs e)
        {
        }

        private void clipModeButton_Click(object sender, EventArgs e)
        {
            AnemoneFrame AF = new AnemoneFrame();
            AF.Show();
            // AF.SelectBitmap(Resources.ring, 255);
            AF.InputText("지난해 일본에서 러브라이브 유저가 300만엔 이상을 과금한 이후 개인파산 신청을 했다는 소식이 있었습니다. 일본에는 이런일이 많은 듯 합니다. 이에 일본 법원의 대응이 게임결제는 면책불가입니다....");
        }
    }
}
