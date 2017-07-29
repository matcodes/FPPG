using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FanDuel.Views.Panels
{
    #region ResultPanel
    public class ResultPanel : BasePanel
    {
        #region Static members
        private static readonly string TOP_TEXT = "GAME OVER";
		private static readonly string QUESTIONS_TEXT = "# of Attempts:";
		private static readonly string ANSWERS_TEXT = "Correct Answers:";
		private static readonly string CONTINUE_TEXT = "Continue";
        #endregion

        public ResultPanel() : base()
        {
            var content = new Grid {
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Center,
                RowSpacing = 20,
                ColumnSpacing = 0,
                RowDefinitions = {
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) }
                }
            };
            content.Children.Add(this.CreateTopText(), 0, 0);
            content.Children.Add(this.CreateQuestions(), 0, 1);
            content.Children.Add(this.CreateQuestionsValue(), 0, 1);
            content.Children.Add(this.CreateAnswers(), 0, 2);
            content.Children.Add(this.CreateAnswersValue(), 0, 2);
            content.Children.Add(this.CreateButton(), 0, 3);

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

            return label;
        }

        private View CreateQuestions()
        {
            var label = new Label
            {
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center,
                FontSize = 20,
                TextColor = Color.Black,
                Text = QUESTIONS_TEXT
            };

            return label;
        }

        private View CreateQuestionsValue()
        {
            var label = new Label
            {
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.Center,
                FontSize = 20,
                TextColor = Color.Black
            };
            label.SetBinding(Label.TextProperty, "Questions");

            return label;
        }

        private View CreateAnswers()
        {
            var label = new Label
            {
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center,
                FontSize = 20,
                TextColor = Color.Black,
                Text = ANSWERS_TEXT
            };

            return label;
        }

        private View CreateAnswersValue()
        {
            var label = new Label
            {
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.Center,
                FontSize = 20,
                TextColor = Color.Black,
            };
            label.SetBinding(Label.TextProperty, "Answers");

            return label;
        }

        private View CreateButton()
        {
            var button = new Button {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                WidthRequest = 200,
                FontSize = 20,
                Text = CONTINUE_TEXT,
                TextColor = Color.White,
                BackgroundColor = Color.Blue,
                BorderColor = Color.Blue,
                BorderRadius = 4
            };
            button.SetBinding(Button.CommandProperty, "ContinueCommand");

            return button;
        }
    }
    #endregion
}
