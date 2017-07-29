using System;
using Xamarin.Forms;

namespace FanDual.Controls
{
    #region AppImage
    public class AppImage : Image
    {
		#region Static members
		public static readonly BindableProperty StrokeWidthProperty = BindableProperty.Create("StrokeWidth", typeof(double), typeof(AppImage), (double)1);
		public static readonly BindableProperty StrokeColorProperty = BindableProperty.Create("StrokeColor", typeof(Color), typeof(AppImage), Color.White);
		#endregion

        public AppImage()
        {
        }

		public double StrokeWidth
		{
			get { return (double)this.GetValue(StrokeWidthProperty); }
			set { this.SetValue(StrokeWidthProperty, value); }
		}

		public Color StrokeColor
		{
			get { return (Color)this.GetValue(StrokeColorProperty); }
			set { this.SetValue(StrokeColorProperty, value); }
		}
	}
    #endregion
}
