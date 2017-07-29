using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FanDuel.Views.Panels
{
    #region BasePanel
    public class BasePanel : ContentView
    {
        public BasePanel() : base()
        {
            this.HorizontalOptions = LayoutOptions.Fill;
            this.VerticalOptions = LayoutOptions.Fill;

            this.Padding = new Thickness(30, 50, 30, 50);
        }
    }
    #endregion
}
