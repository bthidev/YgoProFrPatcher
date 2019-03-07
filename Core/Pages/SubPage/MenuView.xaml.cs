using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YgoProFrPatcher.Core.ViewModels.Page;

namespace YgoProFrPatcher.Core.Pages.SubPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxMasterDetailPagePresentation(MasterDetailPosition.Master)]
    // ReSharper disable once RedundantExtendsListEntry
    public partial class MenuView : MvxContentPage<MenuViewModel>
    {
        public MenuView()
        {
            InitializeComponent();
            
        }

        void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
                if (Xamarin.Forms.Application.Current.MainPage is MasterDetailPage masterDetailPage)
                {
                    masterDetailPage.IsPresented = false;
                }
                else if (Xamarin.Forms.Application.Current.MainPage is NavigationPage navigationPage && navigationPage.CurrentPage is MasterDetailPage nestedMasterDetail)
                {
                    nestedMasterDetail.IsPresented = false;
                }
        }
    }
}