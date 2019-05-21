using MvvmCross.Forms.Presenters.Attributes;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YgoProFrPatcher.Core.Resources;
using YgoProFrPatcher.Core.ViewModels.Page;

namespace YgoProFrPatcher.Core.Pages.Home
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxContentPagePresentation(NoHistory = true)]
    public partial class Home
    {
        public Home()
        {
            InitializeComponent();
            Title = "Ygopro Percy";
            
        }

        private void Button_Clicked(object sender, System.EventArgs e)
        {
            if (File.Exists("ygopro_vs.exe"))
            {
                Process.Start("ygopro_vs.exe");
            }
            else if (File.Exists("ygopro_vs_links.exe"))
            {
                Process.Start("ygopro_vs_links.exe");
            }
            else 
            {
                var test = Directory.GetDirectories(GlobalStyles.GetRoot);
                var temp =  GlobalStyles.GetRoot + "Ygopro.app/Contents/MacOS/Ygopro";
                Process.Start(temp);
            }
        }

        private void Button_Clicked_1(object sender, System.EventArgs e)
        {
            Device.OpenUri(new System.Uri("https://github.com/speedi57/YgoProFrPatcher/issues"));
        }

        private void Button_Clicked_2(object sender, System.EventArgs e)
        {
            Device.OpenUri(new System.Uri("https://github.com/speedi57/YgoProFrPatcher/wiki"));
        }

        private void Picker_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            SwitchAuto.IsToggled = true;
        }
    }
}