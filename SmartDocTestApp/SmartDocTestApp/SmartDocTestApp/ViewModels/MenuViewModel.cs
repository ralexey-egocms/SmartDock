using Cirrious.MvvmCross.ViewModels;
using System.Collections.Generic;
using Cirrious.CrossCore;
using SmartDocTestApp.Core.Services.Interfaces;
using System.Collections.ObjectModel;
using SmartDocTestApp.Core.Helpers;

namespace SmartDocTestApp.Core.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {
        readonly IWebService _webService;
        readonly IPreferencesService _preferences;

        public MenuViewModel()
        {
            _webService = Mvx.Resolve<IWebService>();
            _preferences = Mvx.Resolve<IPreferencesService>();
            LoadMenuData();
        }

        private MenuData _menuData;

        public ObservableCollection<InstanseData> Items
        {
            get
            {
                if (_menuData == null)
                    return null;

                return _menuData.Instances;
            }
        }

        public string UserName
        {
            get
            {
                return _preferences.Username;
            }
        }

        public MvxCommand OnLogOutCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    _preferences.Username = string.Empty;
                    _preferences.Password = string.Empty;
                    ShowViewModel<LoginViewModel>();
                });
            }
        }

        private async void LoadMenuData()
        {
            IsLoading = true;
            _menuData = await _webService.GetMenuData(_currentStateService.CurrentUser);
            RaisePropertyChanged(() => Items);
            IsLoading = false;
        }
    }
}