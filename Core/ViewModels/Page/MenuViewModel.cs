using System.Collections.Generic;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace YgoProFrPatcher.Core.ViewModels.Page
{
    public class MenuViewModel : MvxNavigationViewModel
    {
        public List<string> MenuList
        {
            get => _menuList;
            set => SetProperty(ref _menuList, value);
        }
        List<string> _menuList;
        private readonly IMvxNavigationService _navigationService;
        public MenuViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService)
        : base(logProvider, navigationService)
        {
            _menuList = new List<string>();
            _menuList.Add("Home");
            _navigationService = navigationService;
        }

        public void Nav(int id)
        {
            switch (id)
            {
                case 0:
                    _navigationService.Navigate<HomeViewModel>();
                    break;
            }
        }
    }
}
