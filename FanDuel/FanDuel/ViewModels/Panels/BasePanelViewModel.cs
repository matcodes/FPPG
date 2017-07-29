using FanDuel.Classes;
using FanDuel.ViewModels.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace FanDuel.ViewModels.Panels
{
    #region BasePanelViewModel
    public class BasePanelViewModel : BaseViewModel
    {
        public BasePanelViewModel(MainViewModel mainViewModel) : base("", "")
        {
            this.MainViewModel = mainViewModel;
        }

        public MainViewModel MainViewModel { get; private set; }
    }
    #endregion
}
