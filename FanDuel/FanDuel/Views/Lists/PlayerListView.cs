using FanDuel.Classes.Converters;
using FanDuel.Classes.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using FanDual.Controls;

namespace FanDuel.Views.Lists
{
    #region PlayerListView
    public class PlayerListView : BaseListView
    {
        public PlayerListView() : base()
        {
            this.IsPullToRefreshEnabled = false;

            this.RowHeight = 100;

            this.ItemTemplate = new DataTemplate(typeof(PlayerCell));
        }
    }
    #endregion

    #region PlayerCell
    public class PlayerCell : ViewCell
    {
        #region Static members
        public static readonly BindableProperty AnswerStateProperty = BindableProperty.Create("AnswerState", typeof(AnswerStates), typeof(PlayerCell), AnswerStates.None);
        #endregion

        public PlayerCell() : base()
        {
            this.SetBinding(AnswerStateProperty, "AnswerState");

            var content = new Grid {
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Fill,
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

            this.View = content;
        }

        private View CreatePhoto()
        {
            var photo = new AppImage {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                BackgroundColor = Color.White,
                StrokeColor = Color.White,
                HeightRequest = 80,
                WidthRequest = 80,
            };
            photo.SetBinding(Image.SourceProperty, "Photo");

            return photo;
        }

        private View CreateFullName()
        {
            var label = new Label {
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center,
                FontSize = 20,
                TextColor = Color.Black
            };
            label.SetBinding(Label.TextProperty, "FullName");

            return label;
        }

        private View CreatePosition()
        {
            var label = new Label {
                HorizontalOptions = LayoutOptions.Start,
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
    }
    #endregion
}
