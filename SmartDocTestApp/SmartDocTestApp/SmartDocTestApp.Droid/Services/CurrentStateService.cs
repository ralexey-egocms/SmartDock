using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SmartDocTestApp.Core.Services.Interfaces;
using Cirrious.MvvmCross.Plugins.JsonLocalisation;
using Cirrious.CrossCore;

namespace SmartDocTestApp.Droid.Services
{
    public class CurrentStateService : ICurrentStateService
    {
        public void SetupTextProvider(string lang)
        {
            var _builder = Mvx.Resolve<IMvxTextProviderBuilder>();
            _builder.LoadResources(lang);
        }
    }
}