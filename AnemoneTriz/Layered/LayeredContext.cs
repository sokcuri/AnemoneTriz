using System;
using SkiaSharp;
using AnemoneTriz.Components;
using static AnemoneTriz.Interop.NativeMethods;

namespace AnemoneTriz
{
    public class LayeredContext : SKCanvas
    {
        RawPoint emptyPoint = new RawPoint(0, 0);

        internal RawPoint targetPosition;

        IntPtr target;
        LayeredBuffer buffer;

        public LayeredContext(IntPtr target, LayeredBuffer buffer) : base(buffer.Bitmap)
        {
            this.target = target;
            this.buffer = buffer;
        }

        public void Present()
        {
            var screenSize = buffer.Size;

            UpdateLayeredWindow(
                target,
                buffer.screenDc,
                ref targetPosition, ref screenSize,
                buffer.memDc,
                ref emptyPoint, 0,
                ref buffer.blendFunc,
                ULW_ALPHA);
        }
    }
}