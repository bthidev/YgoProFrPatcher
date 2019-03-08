using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using YgoProFrPatcher.Core.ViewModels.Page;

namespace YgoProFrPatcher.Core.ViewModels
{
    public class RootPageViewModel : MvxNavigationViewModel
    {
        private readonly IMvxNavigationService _navigationService;


        public MvxAsyncCommand ShowInitialViewModelsCommand { get; }

        public RootPageViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService )
        : base(logProvider, navigationService)
        {
            _navigationService = navigationService;
            ShowInitialViewModelsCommand = new MvxAsyncCommand(InitializeViewModels);

        }

        private async Task InitializeViewModels()
        {
            await _navigationService.Navigate<MenuViewModel>();
            await _navigationService.Navigate<HomeViewModel>();
        }
    }
}
