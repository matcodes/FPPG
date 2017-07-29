using FanDuel.Views.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FanDuel
{
    #region App
    public class App : Application
    {
        public App()
        {
            this.MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
    #endregion
}
