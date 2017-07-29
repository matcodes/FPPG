using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FanDuel.Views.Panels
{
    #region LoadingPanel
    public class LoadingPanel : BasePanel
    {
        #region Static members
        private static readonly string TOP_TEXT = "Loading game content...";
        private static readonly string ERROR_TEXT = "Error loading game content. Try again.";
        private static readonly string RELOAD_TEXT = "Reload";
        #endregion

        public LoadingPanel() : base()
        {
            var content = new StackLayout {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Spacing = 20
            };
            content.Children.Add(this.CreateTopText());
            content.Children.Add(this.CreateBusyIndicator());
            content.Children.Add(this.CreateErrorText());
            content.Children.Add(this.CreateButton());

            this.Content = content;
        }

        private View CreateTopText()
        {
            var label = new Label {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize = 20,
                TextColor = Color.Black,
                Text = TOP_TEXT
            };
            label.SetBinding(Label.IsVisibleProperty, "IsBusy");

            return label;
        }

        private View CreateBusyIndicator()
        {
            var indicator = new ActivityIndicator {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                HeightRequest = 50,
                WidthRequest = 50,
                IsRunning = true
            };
            indicator.SetBinding(Label.IsVisibleProperty, "IsBusy");

            return indicator;
        }

        private View CreateErrorText()
        {
            var label = new Label {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize = 20,
                TextColor = Color.Red,
                Text = ERROR_TEXT
            };
            label.SetBinding(Label.IsVisibleProperty, "IsError");

            return label;
        }

        private View CreateButton()
        {
            var button = new Button {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                WidthRequest = 200,
                FontSize = 20,
                Text = RELOAD_TEXT,
                TextColor = Color.White,
                BackgroundColor = Color.Blue,
                BorderColor = Color.Blue,
                BorderRadius = 4
            };
            button.SetBinding(Button.IsVisibleProperty, "IsError");
            button.SetBinding(Button.CommandProperty, "ReloadCommand");

            return button;
        }
    }
    #endregion
}
