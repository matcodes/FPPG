using System;
using System.Windows.Input;
using FanDual.Controls;
using FanDuel.Classes.Converters;
using FanDuel.Classes.Enums;
using Xamarin.Forms;

namespace FanDual.Views.Data
{
    #region HorizontalPlayerView
    public class HorizontalPlayerView : ContentView
    {
		#region Static members
		public static readonly BindableProperty AnswerStateProperty = BindableProperty.Create("AnswerState", typeof(AnswerStates), typeof(VerticalPlayerView), AnswerStates.None);
		public static readonly BindableProperty ClickCommandProperty = BindableProperty.Create("ClickCommand", typeof(ICommand), typeof(VerticalPlayerView), null);
		#endregion

		public HorizontalPlayerView() : base()
        {
            this.BackgroundColor = Color.Silver;

            this.SetBinding(HorizontalPlayerView.AnswerStateProperty, "AnswerState");

			var content = new Grid
			{
				HorizontalOptions = LayoutOptions.Fill,
				VerticalOptions = LayoutOptions.Fill,
                HeightRequest = 100,
				RowSpacing = 10,
				ColumnSpacing = 10,
				Padding = new Thickness(0, 10, 0, 10),
				RowDefinitions = {
					new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
					new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }
				},
				ColumnDefinitions = {
					new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) },
					new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
				}
			};
			content.Children.Add(this.CreatePhoto(), 0, 1, 0, 2);
			content.Children.Add(this.CreateFullName(), 1, 0);
			content.Children.Add(this.CreatePosition(), 1, 1);

			content.SetBinding(Grid.BackgroundColorProperty, new Binding("AnswerState", BindingMode.OneWay, new AnswerStateToColorValueConverter(), null, null, this));

			var tapGesture = new TapGestureRecognizer
			{
			};
			tapGesture.Tapped += (sender, args) =>
			{
				if ((this.ClickCommand != null) && (this.ClickCommand.CanExecute(this.BindingContext)))
					this.ClickCommand.Execute(this.BindingContext);
			};

			content.GestureRecognizers.Add(tapGesture);

            this.Content = content;
		}

		private View CreatePhoto()
		{
			var photo = new AppImage
			{
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,
				StrokeColor = Color.White,
				HeightRequest = 80,
				WidthRequest = 80,
			};
			photo.SetBinding(Image.SourceProperty, "Photo");

			return photo;
		}

		private View CreateFullName()
		{
			var label = new Label
			{
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,
				HorizontalTextAlignment = TextAlignment.Center,
				FontSize = 20,
				TextColor = Color.Black
			};
			label.SetBinding(Label.TextProperty, "FullName");

			return label;
		}

		private View CreatePosition()
		{
			var label = new Label
			{
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,
				FontSize = 20,
				TextColor = Color.Black
			};
			label.SetBinding(Label.TextProperty, "Position");

			return label;
		}

		public AnswerStates AnswerState
		{
			get { return (AnswerStates)this.GetValue(AnswerStateProperty); }
			set { this.SetValue(AnswerStateProperty, value); }
		}

		public ICommand ClickCommand
		{
			get { return (ICommand)this.GetValue(ClickCommandProperty); }
			set { this.SetValue(ClickCommandProperty, value); }
		}
	}
    #endregion
}
