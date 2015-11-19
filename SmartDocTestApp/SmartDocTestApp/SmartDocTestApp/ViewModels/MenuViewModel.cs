using Cirrious.MvvmCross.ViewModels;
using System.Collections.Generic;
using Cirrious.CrossCore;
using SmartDocTestApp.Core.Services.Interfaces;
using System.Collections.ObjectModel;

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
            _menuData = new MenuData()
            {
                Instances = new List<InstanseData>() { 
                new InstanseData(){Id = 0, Name = "First"},
                new InstanseData(){Id = 1, Name = "Second"},
                new InstanseData(){Id = 2, Name = "Third"},
                new InstanseData(){Id = 3, Name = "Fourth"},
                new InstanseData(){Id = 4, Name = "Fifth"},
                new InstanseData(){Id = 5, Name = "Sixth"},
                new InstanseData(){Id = 6, Name = "Seventh"},
                new InstanseData(){Id = 7, Name = "Eightth"},
                new InstanseData(){Id = 8, Name = "Nineth"},
                new InstanseData(){Id = 9, Name = "Tenth"},
                new InstanseData(){Id = 10, Name = "Eleventh"},
                }
            };
		}

		private MenuData _menuData;

		public List<InstanseData> MenuItemSourse { 
			get { return _menuData.Instances; }
		}

        public ObservableCollection<InstanseData> Items { get { return new ObservableCollection<InstanseData>(_menuData.Instances); } }

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
