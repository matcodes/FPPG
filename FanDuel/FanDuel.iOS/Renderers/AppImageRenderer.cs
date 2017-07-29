using System;
using System.ComponentModel;
using FanDual.Controls;
using FanDual.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(AppImage), typeof(AppImageRenderer))]
namespace FanDual.iOS.Renderers
{
	#region AppImageRenderer
	public class AppImageRenderer : ImageRenderer
	{
		private AppImage _appImage = null;

		protected override void OnElementChanged(ElementChangedEventArgs<Image> args)
		{
			base.OnElementChanged(args);

			_appImage = (this.Element as AppImage);

			this.CreateCircle();
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs args)
		{
			base.OnElementPropertyChanged(sender, args);

			if ((args.PropertyName == VisualElement.HeightProperty.PropertyName) ||
				(args.PropertyName == VisualElement.WidthProperty.PropertyName))
				this.CreateCircle();
			else if (args.PropertyName == Image.SourceProperty.PropertyName)
				Console.WriteLine(this.Element.Source);
		}

		private void CreateCircle()
		{
			if ((this.Element != null) && (this.Element.Width > 0) && (this.Element.Height > 0))
			{
				double min = Math.Min(this.Element.Width, this.Element.Height);
				Control.Layer.CornerRadius = (float)(min / 2.0);
				Control.Layer.MasksToBounds = false;
				Control.Layer.BorderColor = _appImage.StrokeColor.ToCGColor();
				Control.Layer.BorderWidth = (nfloat)_appImage.StrokeWidth;
				Control.ClipsToBounds = true;
			}
		}
	}
	#endregion
}
