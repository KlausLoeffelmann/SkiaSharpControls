using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SkiaSharpControls
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        void OnCanvasViewTapped(object sender, EventArgs args)
        {

        }

        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            SKPaint paint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = Color.Red.ToSKColor(),
                StrokeWidth = 25
            };

            canvas.DrawCircle(info.Width / 2, info.Height / 2, info.Width/2, paint);

            paint.Style = SKPaintStyle.Fill;
            paint.Color = SKColors.Blue;
            canvas.DrawCircle(args.Info.Width / 2, args.Info.Height / 2, info.Width / 2, paint);
        }
    }
}
