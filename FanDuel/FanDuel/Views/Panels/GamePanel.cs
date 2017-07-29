using FanDuel.Views.Lists;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using FanDuel.ViewModels.Data;
using System.Windows.Input;
using FanDual.Views.Data;

namespace FanDuel.Views.Panels
{
    #region GamePanel
    public class GamePanel : BasePanel
    {
        #region Static members
        private static readonly string TOP_TEXT = "WHO HAS THE HIGHEST FPPG?";
        private static readonly string QUESTIONS_TEXT = "# of Attempts:";
        private static readonly string ANSWERS_TEXT = "Correct Answers:";

        public static readonly BindableProperty PlayersProperty = BindableProperty.Create("Players", typeof(IList<PlayerViewModel>), typeof(GamePanel), null);
        public static readonly BindableProperty ClickCommandProperty = BindableProperty.Create("ClickCommand", typeof(ICommand), typeof(GamePanel), null);
        #endregion

        private Grid _vertical = null;
        private Grid _horizontal = null;

        private View _leftPanel = null;
        private View _rightPanel = null;

        private View _panel_1 = null;
		private View _panel_2 = null;
		private View _panel_3 = null;
		private View _panel_4 = null;
		private View _panel_5 = null;

		public GamePanel() : base()
        {
            _leftPanel = this.CreateVerticalPanel();
            _rightPanel = this.CreateVerticalPanel();

            _panel_1 = this.CreateHorizontalPanel();
            _panel_2 = this.CreateHorizontalPanel();
            _panel_3 = this.CreateHorizontalPanel();
            _panel_4 = this.CreateHorizontalPanel();
            _panel_5 = this.CreateHorizontalPanel();

            _vertical = this.CreateVertical();
            _vertical.Children.Add(_leftPanel, 0, 0);
            _vertical.Children.Add(_rightPanel, 1, 0);

            _horizontal = this.CreateHorizontal();
            _horizontal.Children.Add(_panel_1, 0, 0);
            _horizontal.Children.Add(_panel_2, 0, 1);
            _horizontal.Children.Add(_panel_3, 0, 2);
            _horizontal.Children.Add(_panel_4, 0, 3);
            _horizontal.Children.Add(_panel_5, 0, 4);

			var content = new Grid {
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Fill,
                RowSpacing = 0,
                ColumnSpacing = 0,
                RowDefinitions = {
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) }
                }
            };
            content.Children.Add(this.CreateTopText(), 0, 0);
            content.Children.Add(_vertical, 0, 1);
            content.Children.Add(_horizontal, 0, 1);
            content.Children.Add(this.CreateValues(), 0, 2);

            this.Content = content;

            this.SetBinding(GamePanel.PlayersProperty, "Players");
            this.SetBinding(GamePanel.ClickCommandProperty, "ItemClickCommand");
        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == PlayersProperty.PropertyName)
                this.ShowPanels();
        }

        private View CreateTopText()
        {
            var label = new Label {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Start,
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize = 20,
                TextColor = Color.Black,
                Text = TOP_TEXT
            };

            return label;
        }

        private void ShowPanels()
        {
            _vertical.IsVisible = false;
            _horizontal.IsVisible = false;
            if (this.Players.Count == 2)
            {
                _leftPanel.BindingContext = this.Players[0];
                _rightPanel.BindingContext = this.Players[1];

                _vertical.IsVisible = true;
            }
            else if (this.Players.Count > 2)
            {
                _panel_1.BindingContext = this.Players[0];
                _panel_2.BindingContext = this.Players[1];
                _panel_3.BindingContext = this.Players[2];
                _panel_4.BindingContext = (this.Players.Count > 3 ? this.Players[3] : null);
                _panel_4.IsVisible = (this.Players.Count > 3);
                _panel_5.BindingContext = (this.Players.Count > 4 ? this.Players[4] : null);
                _panel_5.IsVisible = (this.Players.Count > 4);

                _horizontal.IsVisible = true;
            }
        }

        private Grid CreateVertical()
        {
            var grid = new Grid
            {
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Start,
                RowSpacing = 0,
                ColumnSpacing = 1,
                ColumnDefinitions = {
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) } 
                }
            };

            return grid;
        }

        private Grid CreateHorizontal()
        {
            var grid = new Grid {
				HorizontalOptions = LayoutOptions.Fill,
				VerticalOptions = LayoutOptions.Start,
				RowSpacing = 1,
				ColumnSpacing = 0,
				RowDefinitions = {
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) },
					new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) },
					new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) },
					new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) }
				}
			};

            return grid;
        }

        private View CreateVerticalPanel()
        {
            var panel = new VerticalPlayerView
            {
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Center
            };
            panel.SetBinding(VerticalPlayerView.ClickCommandProperty, new Binding(ClickCommandProperty.PropertyName, BindingMode.OneWay, null, null, null, this));

            return panel;
        }

        private View CreateHorizontalPanel()
        {
			var panel = new HorizontalPlayerView
			{
				HorizontalOptions = LayoutOptions.Fill,
				VerticalOptions = LayoutOptions.Start
			};
			panel.SetBinding(HorizontalPlayerView.ClickCommandProperty, new Binding(ClickCommandProperty.PropertyName, BindingMode.OneWay, null, null, null, this));

			return panel;
		}

        private View CreateValues()
        {
            var content = new Grid {
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Fill,
                RowSpacing = 0,
                ColumnSpacing = 10,
                ColumnDefinitions = {
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
                }
            };
            content.Children.Add(this.CreateQuestionsFrame(), 0, 0);
            content.Children.Add(this.CreateAnswersFrame(), 1, 0);

            return content;
        }

        private View CreateQuestionsFrame()
        {
            var grid = new Grid { 
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Start,
                RowSpacing = 0,
                ColumnSpacing = 0
            };
            grid.Children.Add(this.CreateQuestions());
            grid.Children.Add(this.CreateQuestionsValue());

            var frame = new Frame { 
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Start,
                CornerRadius = 2,
                OutlineColor = Color.Black,
                Padding = new Thickness(5),
                Content = grid
            };

            return frame;
        }

        private View CreateAnswersFrame()
        {
			var grid = new Grid
			{
				HorizontalOptions = LayoutOptions.Fill,
				VerticalOptions = LayoutOptions.Start,
				RowSpacing = 0,
				ColumnSpacing = 0
			};
            grid.Children.Add(this.CreateAnswers());
			grid.Children.Add(this.CreateAnswersValue());

			var frame = new Frame
			{
				HorizontalOptions = LayoutOptions.Fill,
				VerticalOptions = LayoutOptions.Start,
                OutlineColor = Color.Black,
                CornerRadius = 2,
				Padding = new Thickness(5),
				Content = grid
			};

			return frame;
		}

        private View CreateQuestions()
        {
            var label = new Label {
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center,
                FontSize = 14,
                TextColor = Color.Black,
                Text = QUESTIONS_TEXT
            };

            return label;
        }

        private View CreateQuestionsValue()
        {
            var label = new Label {
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.Center,
                FontSize = 14,
                TextColor = Color.Black
            };
            label.SetBinding(Label.TextProperty, "Questions");

            return label;
        }

        private View CreateAnswers()
        {
            var label = new Label {
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center,
                FontSize = 14,
                TextColor = Color.Black,
                Text = ANSWERS_TEXT
            };

            return label;
        }

        private View CreateAnswersValue()
        {
            var label = new Label {
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.Center,
                FontSize = 14,
                TextColor = Color.Black,
            };
            label.SetBinding(Label.TextProperty, "Answers");

            return label;
        }

        public IList<PlayerViewModel> Players
        {
            get { return (IList<PlayerViewModel>)this.GetValue(PlayersProperty); }
            set { this.SetValue(PlayersProperty, value); }
        }

        public ICommand ClickCommand
        {
            get { return (ICommand)this.GetValue(ClickCommandProperty); }
            set { this.SetValue(ClickCommandProperty, value); }
        }
    }
    #endregion
}
