using AnemoneTriz.Components;
using AnemoneTriz.Forms;
using AnemoneTriz.Interop;
using SkiaSharp;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

using static AnemoneTriz.Interop.NativeMethods;

namespace AnemoneTriz.Frames
{
    public partial class AnemoneFrame : Form
    {
        private SkiaHelper SKHelper { get; set; }
        private ToolBox AFToolBox { get; set; }

        public AnemoneFrame()
        {
            InitializeComponent();
            this.MinimumSize = new Size(150, 150);
            this.DoubleBuffered = true;
        }

        public void ShowToolBox()
        {
            AFToolBox = new ToolBox(this);
            AFToolBox.Location = new Point(this.Location.X, this.Location.Y + this.Size.Height);
            AFToolBox.Size = new Size(this.Size.Width, AFToolBox.Size.Height);
            AFToolBox.Show();
        }

        public void InputText(string InputString)
        {
            // InputString = "지난해 일본에서 러브라이브 유저가 300만엔 이상을 과금한 이후 개인파산 신청을 했다는 소식이 있었습니다. 일본에는 이런일이 많은 듯 합니다. 이에 일본 법원의 대응이 게임결제는 면책불가입니다....";
            
            SKHelper.ContentText = InputString;
            SKHelper.SwapChain();
            SelectBitmap(SKHelper.CSharp_Bitmap);
        }

        private SkiaHelper CreateSkiaHelper()
        {
            return new SkiaHelper()
            {
                Size = new Components.RawSize
                {
                    Width = this.Width,
                    Height = this.Height
                },
                PostChain = new SkiaHelper.CanvasDelegate((SKCanvas canvas) =>
                {
                    using (var rectPaint = new SKPaint
                    {
                        StrokeWidth = 0,
                        StrokeMiter = 0,
                        StrokeJoin = SKStrokeJoin.Round,
                        StrokeCap = SKStrokeCap.Round,
                        Style = SKPaintStyle.Stroke,
                        Color = SKColor.Parse("666"),
                        TextSize = 32,
                        IsAntialias = true

                    })

                    using (var bgPaint = new SKPaint
                    {
                        StrokeWidth = 0,
                        StrokeMiter = 0,
                        StrokeJoin = SKStrokeJoin.Round,
                        StrokeCap = SKStrokeCap.Round,
                        Style = SKPaintStyle.Fill,
                        Color = SKColor.Parse("33fff9a3"),
                        TextSize = 32,
                        IsAntialias = true

                    })

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
                        SKHelper.Skia_Canvas.Clear(SKColors.Transparent);

                        float x = 10.0f;
                        float y = 5.0f;
                        float measuredWidth = 0;

                        string str = SKHelper.ContentText;
                        while (str != null && str.Length != 0)
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

                        SKHelper.Skia_Canvas.DrawRect(new SKRect(0, 0, Size.Width, Size.Height), bgPaint);
                        SKHelper.Skia_Canvas.DrawRect(new SKRect(0, 0, Size.Width, Size.Height), rectPaint);

                        SKHelper.Skia_Canvas.DrawPath(frameTextPath, outline2Paint);
                        SKHelper.Skia_Canvas.DrawPath(frameTextPath, outlinePaint);
                        SKHelper.Skia_Canvas.DrawPath(frameTextPath, textPaint);

                    }
                })
            };
        }

        protected override CreateParams CreateParams
        {
            get
            {
                SKHelper = CreateSkiaHelper();

                // Add the layered extended style (WS_EX_LAYERED) to this window.
                CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= WS_EX_LAYERED;
                return createParams;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            ShowToolBox();
            base.OnLoad(e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            if (AFToolBox != null)
            {
                AFToolBox.Location = new Point(this.Location.X, this.Location.Y + this.Size.Height);
                AFToolBox.Size = new Size(this.Size.Width, AFToolBox.Size.Height);
            }
            SKHelper.SizeCheckAndRefresh(new Components.RawSize(this.Width, this.Height));
            SelectBitmap(SKHelper.CSharp_Bitmap);
        }
        
        protected override void OnMove(EventArgs e)
        {
            if (AFToolBox != null)
            {
                AFToolBox.Location = new Point(this.Location.X, this.Location.Y + this.Size.Height);
                AFToolBox.Size = new Size(this.Size.Width, AFToolBox.Size.Height);
            }
            base.OnMove(e);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            SKHelper.CopyToGraphics(e.Graphics);
        }

        /// <summary>
        /// Let Windows drag this window for us (thinks its hitting the title 
        /// bar of the window)
        /// </summary>
        /// <param name="message"></param>
        protected override void WndProc(ref Message message)
        {
            switch((AnemoneTriz.Interop.WM)message.Msg)
            {
                case WM.NCHITTEST:
                    {
                        GetClientRect(this.Handle, out var Rect);

                        POINT Point;

                        Point.X = unchecked((short)(long)message.LParam);
                        Point.Y = unchecked((short)((long)message.LParam >> 16));
                        ScreenToClient(this.Handle, ref Point);

                        // Tell Windows that the user is on the title bar (caption)

                        int BorderWidth = 30;

                        Console.WriteLine($"Point.X: {Point.X}, Point.Y: {Point.Y}, Rect.Left: {Rect.Left}, Rect.Right: {Rect.Right}, Rect.Top: {Rect.Top}, Rect.Bottom: {Rect.Bottom}");

                        if (Point.Y < BorderWidth)
                        {
                            if (Point.X < BorderWidth)
                            {
                                message.Result = (IntPtr)HitTestValues.HTTOPLEFT;
                                return;
                            }
                            else if (Point.X > (Rect.Right - BorderWidth))
                            {
                                message.Result = (IntPtr)HitTestValues.HTTOPRIGHT;
                                return;
                            }
                            message.Result = (IntPtr)HitTestValues.HTTOP;
                            return;
                        }
                        /*bottom-left, bottom and bottom-right */
                        if (Point.Y > (Rect.Bottom - BorderWidth))
                        {
                            if (Point.X < BorderWidth)
                            {
                                message.Result = (IntPtr)HitTestValues.HTBOTTOMLEFT;
                                return;
                            }
                            else if (Point.X > (Rect.Right - BorderWidth))
                            {
                                message.Result = (IntPtr)HitTestValues.HTBOTTOMRIGHT;
                                return;
                            }
                            message.Result = (IntPtr)HitTestValues.HTBOTTOM;
                            return;
                        }
                        if (Point.X < BorderWidth)
                        {
                            message.Result = (IntPtr)HitTestValues.HTLEFT;
                            return;
                        }
                        if (Point.X > (Rect.Right - BorderWidth))
                        {
                            message.Result = (IntPtr)HitTestValues.HTRIGHT;
                            return;
                        }
                    }

                    message.Result = (IntPtr)HitTestValues.HTCAPTION;
                    break;

                default:
                    base.WndProc(ref message);
                    break;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="bitmap"></param>
        public void SelectBitmap(Bitmap bitmap)
        {
            SelectBitmap(bitmap, 255);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="bitmap">
        /// 
        /// </param>
        /// <param name="opacity">
        /// Specifies an alpha transparency value to be used on the entire source 
        /// bitmap. The SourceConstantAlpha value is combined with any per-pixel 
        /// alpha values in the source bitmap. The value ranges from 0 to 255. If 
        /// you set SourceConstantAlpha to 0, it is assumed that your image is 
        /// transparent. When you only want to use per-pixel alpha values, set 
        /// the SourceConstantAlpha value to 255 (opaque).
        /// </param>
        public void SelectBitmap(Bitmap bitmap, int opacity)
        {
            if (bitmap == null)
            {
                return;
            }

            // Does this bitmap contain an alpha channel?
            if (bitmap.PixelFormat != PixelFormat.Format32bppArgb && bitmap.PixelFormat != PixelFormat.Format32bppPArgb)
            {
                throw new ApplicationException("The bitmap must be 32bpp with alpha-channel.");
            }

            // Get device contexts
            IntPtr screenDc = GetDC(IntPtr.Zero);
            IntPtr memDc = CreateCompatibleDC(screenDc);
            IntPtr hBitmap = IntPtr.Zero;
            IntPtr hOldBitmap = IntPtr.Zero;

            try
            {
                // Get handle to the new bitmap and select it into the current 
                // device context.
                hBitmap = bitmap.GetHbitmap(Color.FromArgb(0));
                hOldBitmap = SelectObject(memDc, hBitmap);

                Console.WriteLine($"bitmap.Width: {bitmap.Width}, bitmap.Height: {bitmap.Height}");

                // Set parameters for layered window update.
                RawSize newSize = new RawSize(bitmap.Width, bitmap.Height);
                RawPoint sourceLocation = new RawPoint(0, 0);
                RawPoint newLocation = new RawPoint(this.Left, this.Top);
                BLENDFUNCTION blend = new BLENDFUNCTION();
                blend.BlendOp = AC_SRC_OVER;
                blend.BlendFlags = 0;
                blend.SourceConstantAlpha = (byte)opacity;
                blend.AlphaFormat = AC_SRC_ALPHA;

                // Update the window.
                UpdateLayeredWindow(
                    this.Handle,     // Handle to the layered window
                    screenDc,        // Handle to the screen DC
                    ref newLocation, // New screen position of the layered window
                    ref newSize,     // New size of the layered window
                    memDc,           // Handle to the layered window surface DC
                    ref sourceLocation, // Location of the layer in the DC
                    0,               // Color key of the layered window
                    ref blend,       // Transparency of the layered window
                    ULW_ALPHA        // Use blend as the blend function
                    );
            }
            finally
            {
                // Release device context.
                ReleaseDC(IntPtr.Zero, screenDc);
                if (hBitmap != IntPtr.Zero)
                {
                    SelectObject(memDc, hOldBitmap);
                    DeleteObject(hBitmap);
                }
                DeleteDC(memDc);
            }
        }
    }
}
