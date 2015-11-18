using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartDocTestApp.Core.Services.Interfaces;
using SmartDocTestApp.Core;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Plugins.JsonLocalisation;

namespace SmartDocTestApp.Phone.Services
{
    class CurrentStateService: ICurrentStateService
    {
        public LoginObject CurrentUser
        {
            get;
            set;
        }

        List<string> _curLocals = new List<string>() {
			"no",
		};

        public void SetupTextProvider()
        {
            string lang = System.Threading.Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName;
            var _builder = Mvx.Resolve<IMvxTextProviderBuilder>();
            _builder.LoadResources(_curLocals.Contains(lang) ? lang : "");
            
        }
    }
}
