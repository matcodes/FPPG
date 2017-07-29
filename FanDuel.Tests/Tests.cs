using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using System.Threading.Tasks;
using FanDuel.ViewModels.Pages;

namespace FanDuel.Tests
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        private MainViewModel _mainViewModel = null;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);

            _mainViewModel = new MainViewModel();
        }

        [Test]
        public async Task InitializeTest()
        {
            await _mainViewModel.LoadingPanelViewModel.Initialize();

            Assert.IsFalse(_mainViewModel.LoadingPanelViewModel.IsBusy);
            Assert.IsFalse(_mainViewModel.LoadingPanelViewModel.IsError);
            Assert.IsTrue(_mainViewModel.FilePlayers != null);
            Assert.IsTrue(_mainViewModel.FilePlayers.Players != null);
            Assert.IsTrue(_mainViewModel.FilePlayers.Players.Length > 0);
        }
    }
}

