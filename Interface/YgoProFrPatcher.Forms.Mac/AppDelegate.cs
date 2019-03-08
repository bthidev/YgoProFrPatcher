using Foundation;
using MvvmCross.Forms.Platforms.Mac.Core;
using AppKit;
using YgoProFrPatcher.Core;

namespace YgoProFrPatcher.Forms.Mac
{
    [Register("AppDelegate")]
    public class AppDelegate : MvxFormsApplicationDelegate<Setup, App, FormsApp>
    {
        public override bool ApplicationShouldTerminateAfterLastWindowClosed(NSApplication sender)
        {
            return true;
        }
    }

    public class Setup : MvxFormsMacSetup<App, FormsApp>
    {
    }
}