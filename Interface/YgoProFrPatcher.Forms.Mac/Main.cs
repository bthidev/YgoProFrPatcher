using System.IO;
using AppKit;

namespace YgoProFrPatcher.Forms.Mac
{
    static class MainClass
    {
        static void Main(string[] args)
        {
            NSApplication.Init();
            var temp = (new AppDelegate());
            temp.MainWindow.MaxSize = new CoreGraphics.CGSize(550, 250);
            NSApplication.SharedApplication.Delegate = temp;
            Directory.GetCurrentDirectory();
            NSApplication.Main(args);
        }

    }
}
