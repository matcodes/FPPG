using FanDuel.Classes.Converters;
using FanDuel.ViewModels.Pages;
using FanDuel.Views.Panels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FanDuel.Views.Pages
{
    #region MainPage
    public class MainPage : ContentPage
    {
        #region Static members
        public static readonly BindableProperty StateProperty = BindableProperty.Create("State", typeof(int), typeof(MainPage), AppConstants.MAIN_PAGE_STATE_NONE);
        #endregion

        private IndexToBoolValueConverter _indexToBoolValueConverter = new IndexToBoolValueConverter();

        public MainPage() : base()
        {
            this.BindingContext = new MainViewModel();

            this.SetBinding(MainPage.StateProperty, "State");

            var loadingPanel = this.CreateLoadingPanel();
            var startPanel = this.CreateStartPanel();
            var gamePanel = this.CreateGamePanel();
            var resultPanel = this.CreateResultPanel();

            var content = new Grid {
                HorizontalOptions  = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Fill,
                RowSpacing = 0,
                ColumnSpacing = 0
            };

            content.Children.Add(loadingPanel);
            content.Children.Add(startPanel);
            content.Children.Add(gamePanel);
            content.Children.Add(resultPanel);

            this.Content = content;
        }

        private View CreateLoadingPanel()
        {
            var loadingPanel = new LoadingPanel {
            };
            loadingPanel.SetBinding(LoadingPanel.BindingContextProperty, "LoadingPanelViewModel");
            loadingPanel.SetBinding(LoadingPanel.IsVisibleProperty, new Binding(StateProperty.PropertyName, BindingMode.OneWay, _indexToBoolValueConverter, AppConstants.MAIN_PAGE_STATE_LOADING, null, this));

            return loadingPanel;
        }

        private View CreateStartPanel()
        {
            var startPanel = new StartPanel {
            };
            startPanel.SetBinding(StartPanel.BindingContextProperty, "StartPanelViewModel");
            startPanel.SetBinding(StartPanel.IsVisibleProperty, new Binding(StateProperty.PropertyName, BindingMode.OneWay, _indexToBoolValueConverter, AppConstants.MAIN_PAGE_STATE_START, null, this));

            return startPanel;
        }

        private View CreateGamePanel()
        {
            var gamePanel = new GamePanel {
            };
            gamePanel.SetBinding(GamePanel.BindingContextProperty, "GamePanelViewModel");
            gamePanel.SetBinding(GamePanel.IsVisibleProperty, new Binding(StateProperty.PropertyName, BindingMode.OneWay, _indexToBoolValueConverter, AppConstants.MAIN_PAGE_STATE_GAME, null, this));

            return gamePanel;
        }

        private View CreateResultPanel()
        {
            var resultPanel = new ResultPanel {
            };
            resultPanel.SetBinding(ResultPanel.BindingContextProperty, "ResultPanelViewModel");
            resultPanel.SetBinding(ResultPanel.IsVisibleProperty, new Binding(StateProperty.PropertyName, BindingMode.OneWay, _indexToBoolValueConverter, AppConstants.MAIN_PAGE_STATE_RESULT, null, this));

            return resultPanel;
        }

        public int State
        {
            get { return (int)this.GetValue(StateProperty); }
            set { this.SetValue(StateProperty, value); }
        }
    }
    #endregion
}
