using Cirrious.MvvmCross.ViewModels;
using Cirrious.CrossCore;
using SmartDocTestApp.Core.Services.Interfaces;

namespace SmartDocTestApp.Core.ViewModels
{
	public class LoginViewModel 
		: BaseViewModel
	{
		public LoginViewModel () : base ()
		{
			Mvx.Resolve<ICurrentStateService> ().SetupTextProvider ();
		}

		private string _login = "";

		public string Login { 
			get { return _login; }
			set {
				_login = value;
				RaisePropertyChanged (() => Login);
			}
		}

		private string _password = "";

		public string Password { 
			get { return _password; }
			set {
				_password = value;
				RaisePropertyChanged (() => Password);
			}
		}

		private string _errorMessage = "";

		public string Error { 
			get { return _errorMessage; }
			set {
				_errorMessage = value;
				RaisePropertyChanged (() => Error);
			}
		}

		public MvxCommand OnLoginCommand {
			get { 
				return new MvxCommand (() => {					
					ShowViewModel<MenuViewModel> ();					
				});
			}
		}
	}
}
