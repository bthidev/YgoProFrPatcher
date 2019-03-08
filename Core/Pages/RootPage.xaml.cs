using MvvmCross.Forms.Presenters.Attributes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace YgoProFrPatcher.Core.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxMasterDetailPagePresentation(MasterDetailPosition.Root)]
    public partial class RootPageView
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
#pragma warning disable 4014
            ViewModel.ShowInitialViewModelsCommand.ExecuteAsync();
#pragma warning restore 4014
            MasterBehavior = MasterBehavior.Popover;
            IsPresented = false;

        }
    }
}
