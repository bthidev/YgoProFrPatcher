using System;
using System.Diagnostics;
using MvvmCross.Forms.Presenters.Attributes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace YgoProFrPatcher.Core.Home
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxMasterDetailPagePresentation(MasterDetailPosition.Detail, NoHistory = true)]
    public partial class Home
    {
        public Home()
        {
            InitializeComponent();
            Title = "Home";
        }
     
    }
}