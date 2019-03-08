using System.IO;
using AppKit;

namespace YgoProFrPatcher.Forms.Mac
{
    static class MainClass
    {
        static void Main(string[] args)
        {
            NSApplication.Init();
            NSApplication.SharedApplication.Delegate = new AppDelegate();
            Directory.GetCurrentDirectory();
            NSApplication.Main(args);
        }

    }
}
