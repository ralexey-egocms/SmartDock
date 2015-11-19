using Cirrious.CrossCore;
using Cirrious.MvvmCross.Localization;
using Cirrious.MvvmCross.Plugins.JsonLocalisation;
using Cirrious.MvvmCross.ViewModels;
using SmartDocTestApp.Core.Services.Interfaces;

namespace SmartDocTestApp.Core.ViewModels
{
    public class BaseViewModel
        : MvxViewModel
    {
        protected readonly ICurrentStateService _currentStateService;

        public BaseViewModel()
        {
            _currentStateService = Mvx.Resolve<ICurrentStateService>();
        }

        #region Locallization

        public IMvxLanguageBinder TextSource
        {
            get
            {
                var x = new MvxLanguageBinder(Helper.SmartDockConstants.GeneralNamespace, this.GetType().Name);
                return x;
            }
        }

        IMvxTextProvider _textProvider;

        IMvxTextProvider TextProvider
        {
            get
            {
                if (_textProvider == null)
                {
                    _textProvider = Mvx.Resolve<IMvxTextProvider>();
                }
                return _textProvider;
            }
        }

        public string GetLocalizedError(string field)
        {
            return GetLocalizedText(Helper.SmartDockConstants.ErrorsResource, field);
        }

        public string GetLocalizedText(string source, string field)
        {
            return TextProvider.GetText(Helper.SmartDockConstants.GeneralNamespace, source, field);
        }

        #endregion

        private bool _isLoading;

        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }
            set
            {
                _isLoading = value;
                RaisePropertyChanged(() => IsLoading);
            }
        }
    }
}
