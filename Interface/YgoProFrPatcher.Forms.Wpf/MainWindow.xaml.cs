using System.Diagnostics;
using System.Windows;
using MvvmCross.Forms.Platforms.Wpf.Views;

namespace YgoProFrPatcher.Forms.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MvxFormsWindowsPage
    {
        public MainWindow()
        {
            InitializeComponent();
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;
            this.Title = "YgoProFrPatcher v"+ version;
        }
    }
}
