using LibGit2Sharp;
using LibGit2Sharp.Handlers;
using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Plugin.FilePicker;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using YgoProFrPatcher.Core.Model;
using YgoProFrPatcher.Core.Resources;
using YgoProFrPatcher.Core.Service;

namespace YgoProFrPatcher.Core.ViewModels.Page
{
    public class HomeViewModel : MvxNavigationViewModel
    {
        private string _textInterface;
        public string TextInterface
        {
            get => _textInterface;
            set => SetProperty(ref _textInterface, value);
        }
        private string _textCartes;
        public string TextCartes
        {
            get => _textCartes;
            set => SetProperty(ref _textCartes, value);
        }
        private string _textUpdate;
        public string TextUpdate
        {
            get => _textUpdate;
            set => SetProperty(ref _textUpdate, value);
        }
        private string _textBug;
        public string TextBug
        {
            get => _textBug;
            set => SetProperty(ref _textBug, value);
        }
        private string _textStart;
        public string TextStart
        {
            get => _textStart;
            set => SetProperty(ref _textStart, value);
        }
        private string _textTitle;
        public string TextTitle
        {
            get => _textTitle;
            set => SetProperty(ref _textTitle, value);
        }

        private string _interFace;
        public string InterFace
        {
            get => _interFace;
            set
            {
                var newval = false;
                if (value != _interFace) newval = true;
                SetProperty(ref _interFace, value);
                update(newval);
            }
        }
        private string _carte;
        public string Carte
        {
            get => _carte;
            set
            {
                var newval = false;
                if (value != _carte) newval = true;
                SetProperty(ref _carte, value);
                update(newval);
            }
        }
        bool _autoupdate;
        public bool Autoupdate
        {
            get => _autoupdate;
            set
            {
                var newval = false;
                if ( value != _autoupdate) newval = true;
                SetProperty(ref _autoupdate, value);
                update(newval);
            }
        }

        private List<string> _lstLang;
        public List<string> ListLang
        {
            get => _lstLang;
            set
            {
                SetProperty(ref _lstLang, value);
            }
        }

        bool _enableAuto;
        public bool EnableAuto
        {
            get => _enableAuto;
            set
            {
                SetProperty(ref _enableAuto, value);
            }
        }

        IConfigService _configService;
        ConfigModel _config;

        public HomeViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService, IConfigService configService) :
            base(logProvider, navigationService)
        {
            _configService = configService;
            _config = _configService.GetConfig();
            InterFace = _config.lngInterface;
            Carte = _config.lngCard;
            Autoupdate = _config.AutoUpdate;
        }

        private void update(bool update )
        {
            if (InterFace != null && Carte != null && update && Directory.Exists(GlobalStyles.GetRoot + "ypfr/"))
            {
                if ( Carte == "en")
                {
                    Autoupdate = true;
                }
                SetLang(InterFace);
                SetCard(Carte);
                SetAuto(Autoupdate);
                _config.lngInterface = InterFace;
                _config.lngCard = Carte;
                _config.AutoUpdate = Autoupdate;
                _configService.SetConfig(_config);
            }
        }
        private void SetLang(string lang)
        {
            if (lang != null)
            {
                CultureInfo myCultureInfo = new CultureInfo(lang);
                TextStart = AppRessource.ResourceManager.GetString("Lunch", myCultureInfo);
                TextTitle = AppRessource.ResourceManager.GetString("ChooseLangue", myCultureInfo);
                TextInterface = AppRessource.ResourceManager.GetString("ChooseInterface", myCultureInfo);
                TextCartes = AppRessource.ResourceManager.GetString("ChooseCartes", myCultureInfo);
                TextBug = AppRessource.ResourceManager.GetString("Bug", myCultureInfo);
                TextUpdate = AppRessource.ResourceManager.GetString("AutoUpdate", myCultureInfo);
                File.Copy(GlobalStyles.GetRoot + "ypfr/" + lang + " /strings.conf", "./strings.conf", true);
            }
        }
        private void SetCard(string lang)
        {
            if (lang != null)
            {
                File.Copy(GlobalStyles.GetRoot + "ypfr/" + lang + "/cards.cdb", "./cards.cdb", true);
            }
        }
        private void SetAuto(bool enable)
        {
            string exactPath = Path.GetFullPath(GlobalStyles.GetRoot + "expansions /live2017links/.git/config");
            if (File.Exists(GlobalStyles.GetRoot + "ypfr/" + Carte + "/config"))
            {
                EnableAuto = true;

                if (enable)
                {
                    File.Copy(GlobalStyles.GetRoot + "ypfr/" + Carte + " /config", exactPath, true);
                    EnableAuto = true;
                }
                else
                {
                    File.Copy(GlobalStyles.GetRoot + "ypfr/en/config", exactPath, true);

                }
            }
            else
            {
                Autoupdate = false;
                File.Copy(GlobalStyles.GetRoot + "ypfr/en/config", exactPath, true);
                EnableAuto = false;
                CultureInfo myCultureInfo = new CultureInfo(InterFace);
                TextUpdate = AppRessource.ResourceManager.GetString("NopeDispo", myCultureInfo);
            }
        }
        public override async Task Initialize()
        {
            await base.Initialize();
            try
            {
                Repository.Clone("https://github.com/LucienAclantis/ypfr", GlobalStyles.GetRoot + "ypfr/");
            }
            catch (Exception e)
            {
            }
            using (var repo = new Repository(GlobalStyles.GetRoot + "ypfr/"))
            {
                // Credential information to fetch
                LibGit2Sharp.PullOptions options = new LibGit2Sharp.PullOptions();
                options.FetchOptions = new FetchOptions();
                options.FetchOptions.CredentialsProvider = new CredentialsHandler(
                    (url, usernameFromUrl, types) => new UsernamePasswordCredentials() { });

                // User information to create a merge commit
                var signature = new LibGit2Sharp.Signature(
                    new Identity("speedi57", "thiebaut.benjamin@live.fr"), DateTimeOffset.Now);

                // Pull
                Commands.Pull(repo, signature, options);
            }
            List<string> lstlng = new List<string>();
            Autoupdate = _config.AutoUpdate;
            InterFace = (_config.lngInterface);
            Carte = (_config.lngCard);
        }

    }
}