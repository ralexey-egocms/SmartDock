using System;
using SmartDocTestApp.Core;
using Android.Preferences;
using Android.Content;
using DroidApp = Android.App;
using System.Globalization;
using SmartDocTestApp.Core.Services.Interfaces;

namespace SmartDocTestApp.Droid
{
	public class PreferencesService: IPreferencesService
	{

		#region IPreferencesService implementation

		const string UsernameKey = "Username";

		public string Username {
			get {
				return GetString (UsernameKey);
			}
			set {
				SetString (value, UsernameKey);
			}
		}

		const string PasswordKey = "Password";

		public string Password {
			get {
				return GetString (PasswordKey);
			}
			set {
				SetString (value, PasswordKey);
			}
		}

		#endregion

		public ISharedPreferences AppPreferences {
			get {
				return PreferenceManager.GetDefaultSharedPreferences (DroidApp.Application.Context);
			}
		}

		#region Setters

		void SetBool (bool value, string key)
		{
			var editor = AppPreferences.Edit ();
			editor.PutBoolean (key, value);
			editor.Apply ();
		}

		void SetInt (int value, string key)
		{
			var editor = AppPreferences.Edit ();
			editor.PutInt (key, value);
			editor.Apply ();
		}

		void SetFloat (float value, string key)
		{
			var editor = AppPreferences.Edit ();
			editor.PutFloat (key, value);
			editor.Apply ();
		}

		void SetString (string value, string key)
		{
			var editor = AppPreferences.Edit ();
			editor.PutString (key, value);
			editor.Apply ();
		}

		#endregion

		#region Getters

		bool GetBool (string key)
		{
			return AppPreferences.GetBoolean (key, false);
		}

		int GetInt (string key)
		{
			return AppPreferences.GetInt (key, -1);
		}

		float GetFloat (string key)
		{
			return AppPreferences.GetFloat (key, -1);
		}

		string GetString (string key)
		{
			return AppPreferences.GetString (key, string.Empty);
		}

		#endregion
	}
}

