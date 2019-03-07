using AppKit;
using Syncfusion.ListView.XForms.MacOS;
using Xamarin.Forms.Platform.MacOS;

namespace YgoProFrPatcher.Forms.Mac
{
    static class MainClass
    {
        static void Main(string[] args)
        {
            NSApplication.Init();
            NSApplication.SharedApplication.Delegate = new AppDelegate(); 
            NSApplication.Main(args);
        }

    }
}
