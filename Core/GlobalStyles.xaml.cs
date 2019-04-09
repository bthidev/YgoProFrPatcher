using Xamarin.Forms;

namespace YgoProFrPatcher.Core
{
	public partial class GlobalStyles
	{
		public GlobalStyles ()
		{
			InitializeComponent ();
		}
        public static string GetRoot{ get {
                if(Device.RuntimePlatform == Device.WPF)
                    return "./";

                else
                    return "./../../";
            } }
	}
}
