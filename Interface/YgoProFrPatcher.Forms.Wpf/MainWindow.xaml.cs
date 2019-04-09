using System.Diagnostics;

namespace YgoProFrPatcher.Forms.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;
            this.ResizeMode = System.Windows.ResizeMode.NoResize;
            WindowStyle = System.Windows.WindowStyle.ToolWindow;
            Title = "YgoproLauncher v" + version;
        }
    }
}
