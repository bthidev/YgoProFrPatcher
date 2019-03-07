using Foundation;
using MvvmCross.Forms.Platforms.Mac.Core;
using AppKit;
using YgoProFrPatcher.Core;

namespace YgoProFrPatcher.Forms.Mac
{
    [Register("AppDelegate")]
    public class AppDelegate : MvxFormsApplicationDelegate<Setup, Core.App, FormsApp>
    {
        public override bool ApplicationShouldTerminateAfterLastWindowClosed(NSApplication sender)
        {
            return true;
        }
    }

    public class Setup : MvxFormsMacSetup<Core.App, FormsApp>
    {
        protected override void InitializePlatformServices()
        {
            base.InitializePlatformServices();
        }

        protected override void InitializeLastChance()
        {
            base.InitializeLastChance();
        }
    }
}