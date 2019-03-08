using MvvmCross.Forms.Presenters.Attributes;
using Xamarin.Forms.Xaml;

namespace YgoProFrPatcher.Core.Pages.Home
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxMasterDetailPagePresentation(NoHistory = true)]
    public partial class Home
    {
        public Home()
        {
            InitializeComponent();
            Title = "Home";
        }
     
    }
}