using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FanDuel.Views.Panels
{
    #region StartPanel
    public class StartPanel : BasePanel
    {
        #region Static members
        private static readonly string TOP_TEXT = "WELCOME TO FPPG";
        private static readonly string INFO_TEXT_0 = "Guess The Player With The Highest FPPG Score";
        private static readonly string INFO_TEXT_1 = "Guess 10 Correctly And Win Bragging Rights";
        private static readonly string INFO_TEXT_2 = "Ready?";
        private static readonly string INFO_TEXT_3 = "Select the Number of Players (from 2 to 5) and Click START";
        private static readonly string INFO_TEXT_4 = "The More Players You Choose The More Challenging The Game";
        private static readonly string PLUS_TEXT = "+";
        private static readonly string MINUS_TEXT = "-";
        private static readonly string START_TEXT = "Start";
        #endregion

        public StartPanel() : base()
        {
            var content = new StackLayout {
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Center,
                Spacing = 20
            };

            content.Children.Add(this.CreateTopText(TOP_TEXT));
            content.Children.Add(this.CreateTopText(INFO_TEXT_0));
            content.Children.Add(this.CreateTopText(INFO_TEXT_1));
            content.Children.Add(this.CreateTopText(INFO_TEXT_2));
            content.Children.Add(this.CreateTopText(INFO_TEXT_3));
			content.Children.Add(this.CreateSelector());
            content.Children.Add(this.CreateStartButton());
            content.Children.Add(this.CreateTopText(INFO_TEXT_4));

			this.Content = content;
        }

        private View CreateTopText(string infoText)
        {
            var text = new Label {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize = 20,
                TextColor = Color.Black,
                Text = infoText
            };

            return text;
        }

        private View CreateSelector()
        {
            var selector = new Grid {
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Center,
                RowSpacing = 0,
                ColumnSpacing = 20,
                ColumnDefinitions = {
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) }
                }
            };
            selector.Children.Add(this.CreateDecButton(), 0, 0);
            selector.Children.Add(this.CreatePlayersCount(), 1, 0);
            selector.Children.Add(this.CreateIncButton(), 2, 0);

            return selector;
        }

        private View CreateDecButton()
        {
            var button = new Button {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                WidthRequest = 50,
                FontSize = 20,
                Text = MINUS_TEXT,
                TextColor = Color.White,
                BackgroundColor = Color.Blue,
                BorderColor = Color.Blue,
                BorderRadius = 4
            };
            button.SetBinding(Button.CommandProperty, "DecCommand");

            return button;
        }

        private View CreateIncButton()
        {
            var button = new Button {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                WidthRequest = 50,
                FontSize = 20,
                Text = PLUS_TEXT,
                TextColor = Color.White,
                BackgroundColor = Color.Blue,
                BorderColor = Color.Blue,
                BorderRadius = 4
            };
            button.SetBinding(Button.CommandProperty, "IncCommand");

            return button;
        }

        private View CreatePlayersCount()
        {
            var label = new Label {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize = 20,
                TextColor = Color.Black,
            };
            label.SetBinding(Label.TextProperty, "PlayersCount");

            return label;
        }

        private View CreateStartButton()
        {
            var button = new Button {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                WidthRequest = 200,
                FontSize = 20,
                Text = START_TEXT,
                TextColor = Color.White,
                BackgroundColor = Color.Blue,
                BorderColor = Color.Blue,
                BorderRadius = 4
            };
            button.SetBinding(Button.CommandProperty, "StartCommand");

            return button;
        }
    }
    #endregion
}
