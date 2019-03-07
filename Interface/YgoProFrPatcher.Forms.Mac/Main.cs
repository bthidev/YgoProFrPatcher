using System.IO;
using AppKit;
using Xamarin.Forms.Platform.MacOS;

namespace YgoProFrPatcher.Forms.Mac
{
    static class MainClass
    {
        static void Main(string[] args)
        {
            NSApplication.Init();
            NSApplication.SharedApplication.Delegate = new AppDelegate();
            var temp = Directory.GetCurrentDirectory();
            NSApplication.Main(args);
        }

    }
}
