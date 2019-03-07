using System;
using System.Collections.Generic;
using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YgoProFrPatcher.Core.ViewModels;

namespace YgoProFrPatcher.Core.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxMasterDetailPagePresentation(MasterDetailPosition.Root)]
    public partial class RootPageView : MvxMasterDetailPage<RootPageViewModel>
    {
        public RootPageView()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            IsPresented = false;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.ShowInitialViewModelsCommand.ExecuteAsync();
            this.MasterBehavior = MasterBehavior.Popover;
            IsPresented = false;

        }
    }
}
