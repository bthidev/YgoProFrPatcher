using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Plugin.FilePicker;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace YgoProFrPatcher.Core.ViewModels.Page
{
    public class HomeViewModel : MvxNavigationViewModel
    {
        private string _text;

        public HomeViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService) :
            base(logProvider, navigationService)
        {
            ShowInitialViewModelsCommand = new MvxCommand(run);
            _text = "";
        }

        public MvxCommand ShowInitialViewModelsCommand { get; }
        public string Text
        {
            get => _text;
            set => SetProperty(ref _text, value);
        }
        private void run()
        {
            var test = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceNames();
            var path = CrossFilePicker.Current.PickFile().GetAwaiter().GetResult();
            if (path != null)
            {
                string files = path.FilePath;
                File.Copy("./Resources/cards.cdb", files.Replace(path.FileName, "") + @"cards.cdb", true);
                File.Copy("./Resources/config", files.Replace(path.FileName, "") + @"expansions\live2017links\.git\config", true);
                var frFile = File.ReadAllLines("./Resources/strings.conf");
                var frList = new List<string>(frFile).Where(w => w.StartsWith("!")).ToList();
                var enFile = File.ReadAllLines(files.Replace(path.FileName, "") + @"strings.conf");
                var enList = new List<string>(enFile).Where(w => w.StartsWith("!")).ToList();
                var listFinal = new List<string>();
                listFinal.Add("#The first line is used for comment");
                Console.WriteLine(@"Trans strings.conf");
                foreach (var text in enList)
                {
                    var temp = text.Split(' ')[1];
                    var textAdd = "";
                    var index = frList.FindIndex(w => w.Split(' ')[1] == text.Split(' ')[1]);
                    if (index >= 0)
                    {
                        textAdd = frList[index];
                    }
                    else
                    {
                        textAdd = text;
                    }
                    listFinal.Add(textAdd);
                }
                File.WriteAllLines(files.Replace(path.FileName, "") + @"strings.conf", listFinal.Distinct().ToArray());
                Text = "fini !!";
            }
        }
    }
}