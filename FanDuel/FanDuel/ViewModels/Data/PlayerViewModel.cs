using FanDuel.Classes;
using FanDuel.Classes.Enums;
using FanDuel.Classes.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FanDuel.ViewModels.Data
{
    #region PlayerViewModel
    public class PlayerViewModel : BaseData
    {
        #region Static members
        private static readonly string ANSWER_STATE_PROPERTY_NAME = "AnswerState";
        #endregion

        public PlayerViewModel(FilePlayer filePlayer) : base()
        {
            this.FilePlayer = filePlayer;

            this.Id = this.FilePlayer.Id;
            if ((this.FilePlayer.Images != null) && (this.FilePlayer.Images.Default != null))
                this.Photo = this.FilePlayer.Images.Default.Uri;
            this.FullName = String.Format("{0} {1}", this.FilePlayer.FirstName, this.FilePlayer.LastName);
            this.Position = this.FilePlayer.Position;
            this.FPPG = 0;
            if (this.FilePlayer.FPPG != null)
                this.FPPG = (double)this.FilePlayer.FPPG;
        }

        public FilePlayer FilePlayer { get; private set; }

        public string Id { get; private set; }

        public string Photo { get; private set; }

        public string FullName { get; private set; }

        public string Position { get; private set; }

        public double FPPG { get; private set; }

        public AnswerStates AnswerState
        {
            get { return (AnswerStates)this.GetValue(ANSWER_STATE_PROPERTY_NAME, AnswerStates.None); }
            set { this.SetValue(ANSWER_STATE_PROPERTY_NAME, value); }
        }
    }
    #endregion
}
