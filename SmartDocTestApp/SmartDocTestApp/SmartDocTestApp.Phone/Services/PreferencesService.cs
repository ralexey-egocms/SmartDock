using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartDocTestApp.Core.Services.Interfaces;
using System.IO.IsolatedStorage;

namespace SmartDocTestApp.Phone.Services
{
    class PreferencesService: IPreferencesService
    {
        public IsolatedStorageSettings AppPreferences
        {
            get
            {
                return IsolatedStorageSettings.ApplicationSettings;
            }
        }

        #region IPreferencesService implementation

        const string UsernameKey = "Username";

        public string Username
        {
            get
            {
                return GetString(UsernameKey);
            }
            set
            {
                SetString(value, UsernameKey);
            }
        }

        const string PasswordKey = "Password";

        public string Password
        {
            get
            {
                return GetString(PasswordKey);
            }
            set
            {
                SetString(value, PasswordKey);
            }
        }

        #endregion

        void SetString(string value, string key)
        {
            try
            {                
                if (!AppPreferences.Contains(key))
                {
                    AppPreferences.Add(key, value);
                }
                else
                {
                    AppPreferences[key] = value;
                }
                AppPreferences.Save();
            }
            catch (Exception)
            {                
                //throw;
            }
        }

        string GetString(string key)
        {
            try
            {                
                if (AppPreferences.Contains(key))
                {
                    return AppPreferences[key] as string;
                }
                return "";
            }
            catch (Exception)
            {                
                //throw;
                return "";
            }
        }

    }
}
