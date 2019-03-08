using MvvmCross.Core;
using MvvmCross.Forms.Platforms.Wpf.Core;
using MvvmCross.ViewModels;
using YgoProFrPatcher.Core;
namespace YgoProFrPatcher.Forms.Wpf
{
    public partial class App
    {
        protected override void RegisterSetup()
        {
            this.RegisterSetupType<Setup>();
        }
    }

    public class Setup : MvxFormsWpfSetup<Core.App, FormsApp>
    {
        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }

        protected override Xamarin.Forms.Application CreateFormsApplication()
        {
            return new FormsApp();
        }
    }
}
