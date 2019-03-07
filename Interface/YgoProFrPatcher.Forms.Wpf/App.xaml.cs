using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using MvvmCross;
using MvvmCross.Core;
using MvvmCross.Forms.Platforms.Wpf.Core;
using MvvmCross.IoC;
using MvvmCross.Platforms.Wpf.Views;
using MvvmCross.Plugin.Messenger;
using MvvmCross.ViewModels;
using MvvmCross.Views;
using Plugin.FilePicker;
using Xamarin.Forms;
using YgoProFrPatcher.Core;
namespace YgoProFrPatcher.Forms.Wpf
{
    public partial class App : MvvmCross.Platforms.Wpf.Views.MvxApplication
    {
        protected override void RegisterSetup()
        {
            this.RegisterSetupType<setup>();
        }
    }

    public class setup : MvxFormsWpfSetup<Core.App, FormsApp>
    {
        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }
        protected override void InitializeViewLookup()
        {
            base.InitializeViewLookup();
        }

        protected override Xamarin.Forms.Application CreateFormsApplication()
        {
            return new FormsApp();
        }
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
