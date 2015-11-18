using Cirrious.MvvmCross.ViewModels;
using System.Collections.Generic;
using Cirrious.CrossCore;
using SmartDocTestApp.Core.Services.Interfaces;

namespace SmartDocTestApp.Core.ViewModels
{
	public class MenuViewModel 
		: BaseViewModel
	{
		readonly IWebService _webService;
		readonly IPreferencesService _preferences;

		public MenuViewModel ()
		{
			_webService = Mvx.Resolve<IWebService> ();
			_preferences = Mvx.Resolve<IPreferencesService> ();
            //_menuData = _webService.GetMenuData (_currentStateService.CurrentUser);
		}

		private MenuData _menuData;

		public List<InstanseData> MenuItemSourse { 
			get { return _menuData.Instances; }
		}

		public string UserName {
			get { 
				return _preferences.Username;
			}
		}

		public MvxCommand OnLogOutCommand {
			get { 
				return new MvxCommand (() => {
					_preferences.Username = string.Empty;
					_preferences.Password = string.Empty;
					ShowViewModel<LoginViewModel> ();
				});
			}
		}
	}
}
