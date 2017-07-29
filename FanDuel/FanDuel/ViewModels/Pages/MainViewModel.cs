using FanDuel.Classes;
using FanDuel.Classes.Models;
using FanDuel.ViewModels.Panels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FanDuel.ViewModels.Pages
{
    #region MainViewModel
    public class MainViewModel : BaseViewModel
    {
        #region Static Members
        public static readonly string MAIN_VIEW_MODEL_TITLE = "Fan Dual";
        public static readonly string MAIN_VIEW_MODEL_DESCRIPTION = "Fan Dual Application";

        private static readonly string STATE_PROPERTY_NAME = "State";
        #endregion

        public MainViewModel() : base(MAIN_VIEW_MODEL_TITLE, MAIN_VIEW_MODEL_DESCRIPTION)
        {
            this.LoadingPanelViewModel = new LoadingPanelViewModel(this);
            this.StartPanelViewModel = new StartPanelViewModel(this);
            this.GamePanelViewModel = new GamePanelViewModel(this);
            this.ResultPanelViewModel = new ResultPanelViewModel(this);

            this.State = AppConstants.MAIN_PAGE_STATE_LOADING;
        }

        protected override void DoPropertyChanged(string propertyName)
        {
            base.DoPropertyChanged(propertyName);

            if (propertyName == STATE_PROPERTY_NAME)
                this.InitializePanel();
        }

        private async void InitializePanel()
        {
            if (this.State == AppConstants.MAIN_PAGE_STATE_LOADING)
                await this.LoadingPanelViewModel.Initialize();
            else if (this.State == AppConstants.MAIN_PAGE_STATE_START)
                this.StartPanelViewModel.Initialize();
            else if (this.State == AppConstants.MAIN_PAGE_STATE_GAME)
                this.GamePanelViewModel.Initialize();
            else if (this.State == AppConstants.MAIN_PAGE_STATE_RESULT)
                this.ResultPanelViewModel.Initialize();
        }

        public int State
        {
            get { return (int)this.GetValue(STATE_PROPERTY_NAME, AppConstants.MAIN_PAGE_STATE_NONE); }
            set
            {
                if (this.State != value)
                    this.SetValue(STATE_PROPERTY_NAME, value);
            }
        }

        public FilePlayers FilePlayers { get; set; }

        public int PlayersCount { get; set; }

        public int Questions { get; set; }

        public int Answers { get; set; }

        #region PanelsViewModel
        public LoadingPanelViewModel LoadingPanelViewModel { get; private set; }

        public StartPanelViewModel StartPanelViewModel { get; private set; }

        public GamePanelViewModel GamePanelViewModel { get; private set; }

        public ResultPanelViewModel ResultPanelViewModel { get; private set; }
        #endregion
    }
    #endregion
}
