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
using Java.Util;

namespace SmartDocTestApp.Droid.Services
{
	public class CurrentStateService : ICurrentStateService
	{
		List<string> _curLocals = new List<string> () {
			"no",
		};

		public void SetupTextProvider ()
		{
			string lang = Java.Util.Locale.Default.Language;
			var _builder = Mvx.Resolve<IMvxTextProviderBuilder> ();
			_builder.LoadResources (_curLocals.Contains (lang) ? lang : "");
		}
	}
}