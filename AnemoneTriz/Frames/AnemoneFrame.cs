using AnemoneTriz.Components;
using SkiaSharp;
using System;
using System.Text;
using System.Windows.Forms;

namespace AnemoneTriz.Frames
{
    public partial class AnemoneFrame : Form
    {
        private String InputString { get; set; }
        private SkiaHelper SKHelper { get; set; }

        public AnemoneFrame()
        {
            InputString = "지난해 일본에서 러브라이브 유저가 300만엔 이상을 과금한 이후 개인파산 신청을 했다는 소식이 있었습니다. 일본에는 이런일이 많은 듯 합니다. 이에 일본 법원의 대응이 게임결제는 면책불가입니다....";
            SKHelper = new SkiaHelper()
            {
                Size = new RawSize
                {
                    Width = this.Width,
                    Height = this.Height
                },
                PostChain = new SkiaHelper.CanvasDelegate((SKCanvas canvas) =>
                {
                    using (var textPaint = new SKPaint
                    {
                        Typeface = SKFontManager.Default.MatchCharacter('가'),
                        StrokeWidth = 0,
                        StrokeMiter = 0,
                        StrokeJoin = SKStrokeJoin.Round,
                        StrokeCap = SKStrokeCap.Round,
                        Style = SKPaintStyle.StrokeAndFill,
                        Color = SKColor.Parse("FFFFFFFF"),
                        TextSize = 32,
                        IsAntialias = true

                    })
                    using (var outlinePaint = new SKPaint
                    {
                        Style = textPaint.Style,
                        Typeface = textPaint.Typeface,
                        TextSize = textPaint.TextSize,
                        StrokeCap = textPaint.StrokeCap,
                        StrokeJoin = textPaint.StrokeJoin,
                        StrokeMiter = textPaint.StrokeMiter,
                        IsAntialias = textPaint.IsAntialias,

                        StrokeWidth = 3,
                        Color = SKColor.Parse("FF4374D9"),
                    })
                    using (var outline2Paint = new SKPaint
                    {
                        Style = textPaint.Style,
                        Typeface = textPaint.Typeface,
                        TextSize = textPaint.TextSize,
                        StrokeCap = textPaint.StrokeCap,
                        StrokeJoin = textPaint.StrokeJoin,
                        StrokeMiter = textPaint.StrokeMiter,
                        IsAntialias = textPaint.IsAntialias,

                        StrokeWidth = 6,
                        Color = SKColor.Parse("FF5CD1E5")
                    })
                    using (SKPaint preventPaint = new SKPaint
                    {
                        IsAntialias = true,
                        StrokeWidth = 10,
                        Style = SKPaintStyle.StrokeAndFill,
                        Color = SKColors.Black
                    })
                    using (SKPath frameTextPath = new SKPath())
                    {
                        SKHelper.Skia_Canvas.Clear(SKColors.White);

                        float x = 10.0f;
                        float y = 5.0f;
                        float measuredWidth = 0;

                        string str = InputString;
                        while (str.Length != 0)
                        {
                            SKRect bounds = new SKRect();

                            int textLength = (int)textPaint.BreakText(str, Size.Width - 24, out measuredWidth);
                            outline2Paint.MeasureText(str, ref bounds);

                            var b = Encoding.UTF8.GetBytes(str);
                            var s = Encoding.UTF8.GetString(b, 0, textLength);
                            if (bounds.Width > this.Width)
                                textLength -= Encoding.UTF8.GetByteCount($"{s[s.Length - 1]}");

                            s = Encoding.UTF8.GetString(b, textLength, b.Length - textLength);

                            // 띄어쓰기가 짤리면 줄 위로 올린다
                            for (int i = 0; i < s.Length; i++)
                                if (s[i] == ' ') textLength++;
                                else break;

                            y += (int)bounds.Height + 2;

                            using (SKPath textPath = textPaint.GetTextPath(Encoding.UTF8.GetString(b, 0, textLength), x, y))
                            using (SKPath outlinePath = new SKPath())
                            {
                                using (SKPaint tempPaint = new SKPaint
                                {
                                    IsAntialias = true,
                                    Color = SKColors.Black
                                })
                                {
                                    tempPaint.GetFillPath(textPath, outlinePath);
                                    frameTextPath.AddPath(textPath, SKPathAddMode.Append);
                                }
                            }
                            str = Encoding.UTF8.GetString(b, (int)textLength, b.Length - (int)textLength);
                        }

                        SKHelper.Skia_Canvas.DrawPath(frameTextPath, outline2Paint);
                        SKHelper.Skia_Canvas.DrawPath(frameTextPath, outlinePaint);
                        SKHelper.Skia_Canvas.DrawPath(frameTextPath, textPaint);
                    }
                })

            };
            InitializeComponent();
            this.DoubleBuffered = true;
            SKHelper.SwapChain();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            SKHelper.SizeCheckAndRefresh(new RawSize(this.Width, this.Height));
            Invalidate();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            SKHelper.CopyToGraphics(e.Graphics);
        }

        private void AnemoneFrame_Load(object sender, EventArgs e)
        {
            SKHelper.SizeCheckAndRefresh(new RawSize(this.Width, this.Height));
        }
    }
}
