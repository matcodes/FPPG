using FanDuel.Classes;
using FanDuel.ViewModels.Data;
using FanDuel.ViewModels.Pages;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using FanDuel.Classes.Enums;
using System.Threading.Tasks;
using FanDuel.Classes.Extensions;
using Xamarin.Forms;

namespace FanDuel.ViewModels.Panels
{
    #region GamePanelViewModel
    public class GamePanelViewModel : BasePanelViewModel
    {
        #region Static members
        private static readonly string SELECTED_PLAYER_PROPERTY_NAME = "SelectedPlayer";
        private static readonly string PLAYERS_PROPERTY_NAME = "Players";
        private static readonly string QUESTIONS_PROPERTY_NAME = "Questions";
        private static readonly string ANSWERS_PROPERTY_NAME = "Answers";
        #endregion

        private Random _random = new Random();

        public GamePanelViewModel(MainViewModel mainViewModel) : base(mainViewModel)
        {
            this.ItemClickCommand = new VisualCommand(this.ItemClick);
        }

        public override void Initialize(params object[] parameters)
        {
            this.Questions = 0;
            this.Answers = 0;

            this.CreateQuestion();
        }

        private void CreateQuestion()
        {
            var players = new List<PlayerViewModel>();

            var playersLength = this.MainViewModel.FilePlayers.Players.Length;

            while (players.Count < this.MainViewModel.PlayersCount)
            {
                var index = _random.Next(10000) % playersLength;
                if (index >= playersLength)
                    index = playersLength - 1;

                var filePlayer = this.MainViewModel.FilePlayers.Players[index];

                var exist = players.FirstOrDefault(fp => fp.Id == filePlayer.Id);
                if (exist == null)
                    players.Add(new PlayerViewModel(filePlayer));
            }

            this.Questions++;
            this.SelectedPlayer = null;
            this.Players = players.ToArray();
            this.ItemClickCommand.IsEnabled = true;
        }

        private async void ItemClick(object parameter)
        {
            var playerViewModel = (parameter as PlayerViewModel);
            this.SelectedPlayer = null;
            if (playerViewModel != null)
            {
                this.ItemClickCommand.IsEnabled = false;
                var max = this.Players.Max(p => p.FPPG);
                if (playerViewModel.FPPG == max)
                {
                    this.Answers++;
                    playerViewModel.AnswerState = AnswerStates.True;
                }
                else
                    playerViewModel.AnswerState = AnswerStates.False;
            }
            await this.Wait();
        }

        private async Task Wait()
        {
            await Task.Delay(2000);
            this.NextStep();
        }

        private void NextStep()
        {
            Device.BeginInvokeOnMainThread(() => {
                if (this.Answers == 10)
                {
                    this.MainViewModel.Questions = this.Questions;
                    this.MainViewModel.Answers = this.Answers;
                    this.MainViewModel.State = AppConstants.MAIN_PAGE_STATE_RESULT;
                }
                else
                    this.CreateQuestion();
            });
        }

        public PlayerViewModel SelectedPlayer
        {
            get { return (this.GetValue(SELECTED_PLAYER_PROPERTY_NAME) as PlayerViewModel); }
            set { this.SetValue(SELECTED_PLAYER_PROPERTY_NAME, value); }
        }

        public PlayerViewModel[] Players
        {
            get { return (PlayerViewModel[])this.GetValue(PLAYERS_PROPERTY_NAME); }
            set { this.SetValue(PLAYERS_PROPERTY_NAME, value); }
        }

        public int Questions
        {
            get { return (int)this.GetValue(QUESTIONS_PROPERTY_NAME, 0); }
            set { this.SetValue(QUESTIONS_PROPERTY_NAME, value); }
        }

        public int Answers
        {
            get { return (int)this.GetValue(ANSWERS_PROPERTY_NAME, 0); }
            set { this.SetValue(ANSWERS_PROPERTY_NAME, value); }
        }

        public VisualCommand ItemClickCommand { get; private set; }
    }
    #endregion
}
