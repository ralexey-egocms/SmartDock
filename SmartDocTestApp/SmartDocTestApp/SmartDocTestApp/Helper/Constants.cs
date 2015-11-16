using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartDocTestApp.Core.Helper
{
    public static class SmartDockConstants
    {
        public const string GeneralNamespace = "SmartDocTestApp";
        public const string RootFolderForResources = "Localization/Text";
        public const string ErrorsResource = "_Errors";

        static string _locale;

        public static string Locale
        {
            get
            {
                return _locale;
            }
            set
            {
                _locale = value;
            }
        }
    }
}
