using SkiaSharp;
using System.Drawing;
using AnemoneTriz.Components;

namespace AnemoneTriz.Extensions
{
    internal static class RawEx
    {
        public static RawSize ToRawSize(this Size size)
        {
            return new RawSize(size.Width, size.Height);
        }

        public static RawPoint ToRawPoint(this Point point)
        {
            return new RawPoint(point.X, point.Y);
        }

        public static RawSize ToRawSize(this SKSize size)
        {
            return new RawSize((int)size.Width, (int)size.Height);
        }

        public static RawPoint ToRawPoint(this SKPoint point)
        {
            return new RawPoint((int)point.X, (int)point.Y);
        }
    }
}
