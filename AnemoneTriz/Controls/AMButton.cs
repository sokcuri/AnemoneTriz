using SkiaSharp;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using AnemoneTriz.Components;

namespace AnemoneTriz.Controls
{
    [DesignerCategory("Code")]
    public class AMButton : Button
    {
        internal SkiaHelper SKHelper { get; set; }
        internal Timer timer { get; set; }
        internal int alpha { get; set; }
        internal Color color { get; set; }

        #region property
        [CategoryAttribute("GlowButton Attribute")]
        [DescriptionAttribute("하이라이트시 칠할 색상입니다")]
        public Color HighlightColor { get; set; } = Color.Silver;
        #endregion

        // prevent focus appearance of button
        public override void NotifyDefault(bool value)
        {
            base.NotifyDefault(false);
        }
        
        public AMButton()
        {
            timer = new Timer();
            timer.Interval = 10;
            timer.Tick += (object sender, EventArgs e) =>
            {
                alpha += 10;
                color = Color.FromArgb(alpha, HighlightColor);

                if (alpha > 100)
                    timer.Stop();

                Invalidate();
            };

            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 1;
            this.FlatAppearance.BorderColor = Color.LightGray;
            
            SKHelper = new SkiaHelper();
            SKHelper.Size = new RawSize
            {
                Width = this.Width,
                Height = this.Height
            };
            SKHelper.SwapChain();
        }
        
        protected override void OnMouseEnter(EventArgs e)
        {
            timer.Start();
            alpha = 0;
        }
        
        protected override void OnMouseLeave(EventArgs e)
        {
            timer.Stop();
            alpha = 0;
            color = this.BackColor;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            if (alpha > 0)
            {
                SKHelper.SizeCheckAndRefresh(new RawSize(this.Width, this.Height));
                SKHelper.DrawOnGraphics(pevent.Graphics, (SKCanvas canvas) =>
                {
                    canvas.Clear(new SKColor(color.R, color.G, color.B, (byte)alpha));
                });
            }
        }
    }
}
