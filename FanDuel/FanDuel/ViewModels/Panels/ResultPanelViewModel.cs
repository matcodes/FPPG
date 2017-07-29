using FanDuel.Classes;
using FanDuel.ViewModels.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace FanDuel.ViewModels.Panels
{
    #region ResultPanelViewModel
    public class ResultPanelViewModel : BasePanelViewModel
    {
        #region Static members
        private static readonly string QUESTIONS_PROPERTY_NAME = "Questions";
        private static readonly string ANSWERS_PROPERTY_NAME = "Answers";
        #endregion

        public ResultPanelViewModel(MainViewModel mainViewModel) : base(mainViewModel)
        {
            this.ContinueCommand = new VisualCommand(this.Continue);
        }

        public override void Initialize(params object[] parameters)
        {
            base.Initialize(parameters);

            this.Questions = this.MainViewModel.Questions;
            this.Answers = this.MainViewModel.Answers;
        }

        private void Continue(object parameter)
        {
            this.MainViewModel.State = AppConstants.MAIN_PAGE_STATE_START;
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

        public VisualCommand ContinueCommand { get; private set; } 
    }
    #endregion
}
