using FanDuel.Classes;
using FanDuel.Classes.API;
using FanDuel.Classes.Extensions;
using FanDuel.Classes.Models;
using FanDuel.ViewModels.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FanDuel.ViewModels.Panels
{
    #region LoadingPanelViewModel
    public class LoadingPanelViewModel : BasePanelViewModel
    {
        #region Static members
        private static readonly string IS_ERROR_PROPERTY_NAME = "IsError";
        #endregion

        public LoadingPanelViewModel(MainViewModel mainViewModel) : base(mainViewModel)
        {
            this.ReloadCommand = new VisualCommand(this.Reload);
        }

        public new async Task Initialize(params object[] parameters)
        {
            base.Initialize(parameters);

            this.IsError = false;
            await this.LoadContent();
        }

        private async Task LoadContent()
        {
            try
            {
                var filePlayers = await this.GetData();
                this.MainViewModel.FilePlayers = filePlayers;
                this.MainViewModel.State = AppConstants.MAIN_PAGE_STATE_START;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                this.IsError = true;
            }
            finally
            {
                this.IsBusy = false;
            }
        }

        private async Task<FilePlayers> GetData()
        {
            var filePlayers = await Task<FilePlayers>.Run(() => {
                var result = FanDuelAPI.LoadContent();
                return result;
            });
            return filePlayers;
        }

        internal async void Reload(object parameter)
        {
            this.IsError = false;
            await this.LoadContent();
        }

        public bool IsError
        {
            get { return (bool)this.GetValue(IS_ERROR_PROPERTY_NAME, false); }
            set { this.SetValue(IS_ERROR_PROPERTY_NAME, value); }
        }

        public VisualCommand ReloadCommand { get; private set; }
    }
    #endregion
}
