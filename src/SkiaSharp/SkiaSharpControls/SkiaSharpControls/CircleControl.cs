using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using Xamarin.Forms;


namespace SkiaSharpControls
{
    class CircleControl : SKCanvasView
    {
        protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
        {
            bool colorFlag = false;

            base.OnPaintSurface(e);
            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            var sw = Stopwatch.StartNew();

            SKPaint paint = new SKPaint
            {
                Style = SKPaintStyle.Fill,
                TextSize=48,
                StrokeWidth = 25
            };

            var circleCount = Math.Min(info.Width, info.Height) / 2;

            for (int count = circleCount; count >= 0; count-=2)
            {
                paint.Color = (colorFlag^=true) ? SKColors.Blue : SKColors.Red;
                canvas.DrawCircle(count, count, count, paint);
            }
            paint.Color = SKColors.Black;
            sw.Stop();
            var str = $"{sw.ElapsedMilliseconds:#,###} ms.";
            float textWidth = paint.MeasureText(str);
            canvas.DrawText(str, info.Width / 2 - textWidth / 2,
                                 info.Height / 2, paint);

            var stream = new MemoryStream();
            var tmp = new SkiaSharp.SKSvg();
            tmp.Load(stream);
            
            var sm = new SKMatrix
            {
                ScaleX = 10,
                ScaleY = 10,
                TransX = 10,
                TransY = 10
            };

            canvas.DrawPicture(tmp.Picture,ref sm);
        }
    }
}
