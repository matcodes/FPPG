using FanDuel.Classes;
using FanDuel.ViewModels.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FanDuel.ViewModels.Panels
{
    #region StartPanelViewModel
    public class StartPanelViewModel : BasePanelViewModel
    {
        #region Static members
        private static readonly int MIN_PLAYERS_COUNT = 2;
        private static readonly int MAX_PLAYERS_COUNT = 5;

        private static readonly string PLAYERS_COUNT_PROPERTY_NAME = "PlayersCount";
        #endregion

        public StartPanelViewModel(MainViewModel mainViewModel) : base(mainViewModel)
        {
            this.StartCommand = new VisualCommand(this.Start);
            this.IncCommand = new VisualCommand(this.Inc);
            this.DecCommand = new VisualCommand(this.Dec);
        }

        public override void Initialize(params object[] parameters)
        {
            base.Initialize(parameters);

            this.PlayersCount = MIN_PLAYERS_COUNT;
        }

        protected override void DoPropertyChanged(string propertyName)
        {
            if (propertyName == PLAYERS_COUNT_PROPERTY_NAME)
                this.SetCommandsState();

            base.DoPropertyChanged(propertyName);
        }

        private void SetCommandsState()
        {
            Device.BeginInvokeOnMainThread(() => {
                this.DecCommand.IsEnabled = (this.PlayersCount != MIN_PLAYERS_COUNT);
                this.IncCommand.IsEnabled = (this.PlayersCount != MAX_PLAYERS_COUNT);
            });
        }

        private void Start(object parameter)
        {
            this.MainViewModel.PlayersCount = this.PlayersCount;
            this.MainViewModel.State = AppConstants.MAIN_PAGE_STATE_GAME;
        }

        private void Inc(object parameter)
        {
            if (this.PlayersCount < MAX_PLAYERS_COUNT)
                this.PlayersCount++;
        }

        private void Dec(object parameter)
        {
            if (this.PlayersCount > MIN_PLAYERS_COUNT)
                this.PlayersCount = MIN_PLAYERS_COUNT;
        }

        public int PlayersCount
        {
            get { return (int)this.GetValue(PLAYERS_COUNT_PROPERTY_NAME, 0); }
            set { this.SetValue(PLAYERS_COUNT_PROPERTY_NAME, value); }
        } 

        public VisualCommand StartCommand { get; private set; }

        public VisualCommand IncCommand { get; private set; }

        public VisualCommand DecCommand { get; private set; }
    }
    #endregion
}
