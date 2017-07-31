using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FanDuel.ViewModels.Pages;
using System.Threading.Tasks;

namespace FanDuel.Tests
{
    #region LoadingPanelViewModelTest
    [TestClass]
    public class LoadingPanelViewModelTest
    {
        private MainViewModel _mainViewModel;

        [TestInitialize]
        public void TestInitialize()
        {
            _mainViewModel = new MainViewModel();
        }

        [TestMethod]
        public async Task InitializeTest()
        {
            await _mainViewModel.LoadingPanelViewModel.Initialize();

            Assert.IsFalse(_mainViewModel.LoadingPanelViewModel.IsBusy);
            Assert.IsFalse(_mainViewModel.LoadingPanelViewModel.IsError);
            Assert.IsTrue(_mainViewModel.FilePlayers != null);
            Assert.IsTrue(_mainViewModel.FilePlayers.Players != null);
            Assert.IsTrue(_mainViewModel.FilePlayers.Players.Length > 0);
            Assert.IsTrue(_mainViewModel.State == AppConstants.MAIN_PAGE_STATE_START);
        }
    }
    #endregion
}
