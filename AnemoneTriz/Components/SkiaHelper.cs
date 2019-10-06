using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AnemoneTriz.Interop.NativeMethods;

namespace AnemoneTriz.Components
{
    [StructLayout(LayoutKind.Sequential)]
    public struct RawSize
    {
        public int Width;
        public int Height;

        public RawSize(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public Size ToDrawingSize()
        {
            return new Size(Width, Height);
        }

        public SKSize ToSKSize()
        {
            return new SKSize(Width, Height);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RawPoint
    {
        public int X;
        public int Y;

        public RawPoint(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Point ToDrawingPoint()
        {
            return new Point(X, Y);
        }

        public SKPoint ToSKPoint()
        {
            return new SKPoint(X, Y);
        }
    }

    class SkiaHelper
    {
        public RawSize Size { get; set; }

        public delegate void CanvasDelegate(SKCanvas Canvas);
        public CanvasDelegate PostChain { get; set; }

        public RawSize BitmapSize { get; private set; }
        public SKBitmap Skia_Bitmap { get; private set; }
        public SKCanvas Skia_Canvas { get; private set; }
        public Bitmap CSharp_Bitmap { get; private set; }
        public IntPtr Skia_DC { get; private set; }

        internal bool Initialized { get; private set; }
        internal IntPtr screenDc;
        internal IntPtr native;
        internal IntPtr oldBitmap;
        internal IntPtr scan0;


        public void SwapChain()
        {
            if (Initialized == true ||
                Size.Width == 0 ||
                Size.Height == 0)
                return;

            SKImageInfo info;

            try
            {
                info = new SKImageInfo(
                    Size.Width,
                    Size.Height,
                    SKColorType.Bgra8888,
                    SKAlphaType.Premul);
            }
            catch
            {
                return;
            }

            Skia_Bitmap = new SKBitmap();
            CreateNativeContext();

            var result = this.Skia_Bitmap.InstallPixels(
                info, scan0,
                info.RowBytes,
                null, null,
                "RELEASING");

            Skia_Canvas = new SKCanvas(Skia_Bitmap);
            int stride = Size.Width * 4;
            CSharp_Bitmap = new Bitmap(Size.Width, Size.Height, stride, PixelFormat.Format32bppPArgb, scan0);
            BitmapSize = Size;
            
            PostChain?.Invoke(Skia_Canvas);

            // 메모리 회수
            SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
            Initialized = true;
        }

        public void Refresh()
        {
            if (Initialized == false)
                return;

            ReleaseResources();
            SwapChain();
        }

        public void DrawOnGraphics(Graphics graphics, CanvasDelegate canvasDelegate)
        {
            if (Initialized == false)
                return;

            CopyFromGraphics(graphics);

            using (SKBitmap bitmap = new SKBitmap(Size.Width, Size.Height))
            {
                using (SKCanvas canvas = new SKCanvas(bitmap))
                {
                    canvasDelegate(canvas);

                    Skia_Canvas.DrawBitmap(bitmap, new SKRect(0, 0, Size.Width, Size.Height));
                    CopyToGraphics(graphics);
                }
            }
        }

        public void SizeCheckAndRefresh(RawSize CurrentSize)
        {
            if (Initialized == false)
                return;

            if (CurrentSize.Width != BitmapSize.Width ||
                CurrentSize.Height != BitmapSize.Height)
            {
                Size = CurrentSize;
                Refresh();
            }
        }

        public void CopyToGraphics(Graphics graphics)
        {
            if (Initialized == false)
                return;

            var graphicsHDC = graphics.GetHdc();
            BitBlt(graphicsHDC, 0, 0, Size.Width, Size.Height, Skia_DC, 0, 0, TernaryRasterOperations.SRCCOPY);
            graphics.ReleaseHdc(graphicsHDC);

            //var graphicsHDC = graphics.GetHdc();
            //var graphicsHDC_Compatible = CreateCompatibleDC(graphicsHDC);
            //var Skia_DC_Compatible = CreateCompatibleDC(Skia_DC);
            //BitBlt(graphicsHDC_Compatible, 0, 0, Size.Width, Size.Height, Skia_DC_Compatible, 0, 0, TernaryRasterOperations.SRCPAINT);
            //DeleteObject(Skia_DC_Compatible);
            //DeleteObject(graphicsHDC_Compatible);
            //graphics.ReleaseHdc(graphicsHDC);
        }
        public void CopyFromGraphics(Graphics graphics)
        {
            if (Initialized == false)
                return;

            var graphicsHDC = graphics.GetHdc();
            var compatibleDC = CreateCompatibleDC(graphicsHDC);
            BitBlt(Skia_DC, 0, 0, Size.Width, Size.Height, graphicsHDC, 0, 0, TernaryRasterOperations.SRCCOPY);
            DeleteObject(compatibleDC);
            graphics.ReleaseHdc(graphicsHDC);
        }

        internal void CreateNativeContext()
        {
            var bmh = new BITMAPV5HEADER()
            {
                bV5Size = (uint)Marshal.SizeOf(typeof(BITMAPV5HEADER)),
                bV5Width = Size.Width,
                bV5Height = -Size.Height,
                bV5Planes = 1,
                bV5BitCount = 32,
                bV5Compression = BitmapCompressionMode.BI_RGB,
                bV5AlphaMask = ColorMask.Alpha,
                bV5RedMask = ColorMask.Red,
                bV5GreenMask = ColorMask.Green,
                bV5BlueMask = ColorMask.Blue
            };

            screenDc = GetDC(IntPtr.Zero);
            Skia_DC = CreateCompatibleDC(screenDc);
            native = CreateDIBSection(screenDc, ref bmh, 0, out scan0, IntPtr.Zero, 0);
            oldBitmap = SelectObject(Skia_DC, native);
        }

        private void ReleaseResources()
        {
            if (Initialized == false)
                return;

            Skia_Bitmap.Dispose();
            Skia_Canvas.Dispose();
            CSharp_Bitmap.Dispose();

            ReleaseDC(IntPtr.Zero, screenDc);
            SelectObject(Skia_DC, oldBitmap);
            DeleteDC(Skia_DC);

            DeleteObject(native);
            DeleteObject(scan0);
            DeleteObject(oldBitmap);

            Initialized = false;
        }
    }
}
