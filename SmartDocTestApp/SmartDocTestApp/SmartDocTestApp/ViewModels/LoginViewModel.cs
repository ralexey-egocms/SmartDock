using Cirrious.MvvmCross.ViewModels;
using Cirrious.CrossCore;
using SmartDocTestApp.Core.Services.Interfaces;
using SmartDocTestApp.Core.Helpers;
using System.Collections.Generic;
using System;
using SmartDocTestApp.Core.Services;
using System.Net;
using System.Threading.Tasks;

namespace SmartDocTestApp.Core.ViewModels
{
	public class LoginViewModel : BaseViewModel
	{
		readonly IWebService _webService;
		readonly IPreferencesService _preferences;

		public LoginViewModel ()
			: base ()
		{
			_currentStateService.SetupTextProvider ();
			_webService = Mvx.Resolve<IWebService> ();
			_preferences = Mvx.Resolve<IPreferencesService> ();

			if (!string.IsNullOrEmpty (_preferences.Username) && !string.IsNullOrEmpty (_preferences.Password)) {
				Loginnn ();
//                Task.Run(async () =>
//                {
//                    _currentStateService.CurrentUser = await _webService.LogInWP(_preferences.Username, _preferences.Password);
//                    if (_currentStateService.CurrentUser.IsValid)
//                    {
//                        ShowViewModel<MenuViewModel>();
//                    }
//                    else
//                    {
//                        Login = _preferences.Username;
//                        Password = _preferences.Password;
//
//                        Error = GetLocalizedError("UnexpectedError");
//                    }
//                });
			}
		}

		#region properties

		#if DEBUG
		private string _login = "9826908899";
		#else
		private string _login = "";
#endif

		public string Login {
			get { return _login; }
			set {
				_login = value;
				RaisePropertyChanged (() => Login);
			}
		}

		#if DEBUG
		private string _password = "rs1234";
		#else
		private string _password = "";
#endif

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

		#endregion

		public MvxCommand OnLoginCommand {
			get {
				return new MvxCommand (async () => {
					Error = String.Empty;
					if (string.IsNullOrEmpty (Login))
						Error = GetLocalizedError ("UsernameCannotBeEmpty");
					else if (string.IsNullOrEmpty (Password))
						Error = GetLocalizedError ("PasswordCannotBeEmpty");
					else {
						_currentStateService.CurrentUser = await _webService.LogInWP (Login, Password);

						if (_currentStateService.CurrentUser.IsValid) {
							Error = String.Empty;
							_preferences.Username = Login;
							_preferences.Password = Password;
							ShowViewModel<MenuViewModel> ();
						} else {
							Error = GetLocalizedError ("PasswordNotMatch");
						}
					}
				});
			}
		}

		private async void Loginnn ()
		{
			_currentStateService.CurrentUser = await _webService.LogInWP (_preferences.Username, _preferences.Password);
			if (_currentStateService.CurrentUser.IsValid) {
				ShowViewModel<MenuViewModel> ();
			} else {
				Login = _preferences.Username;
				Password = _preferences.Password;
			
				Error = GetLocalizedError ("UnexpectedError");
			}
		}
	}
}