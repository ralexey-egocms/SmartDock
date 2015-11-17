
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
using Cirrious.MvvmCross.Droid.Views;
using Android.Content.PM;

namespace SmartDocTestApp.Droid
{
	public class BaseView : MvxActivity
	{
		public IMenu Menu {
			get;
			set;
		}

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			this.ActionBar.Show ();
//			this.ActionBar.Title = "SmartDoc";
			this.ActionBar.SetDisplayShowCustomEnabled (true);
			this.ActionBar.SetCustomView (Resource.Layout.actionbar_layout);
		}

		public override void OnBackPressed ()
		{
//			base.OnBackPressed ();
		}

		public virtual bool OnCreateOptionsMenu (Menu menu)
		{
			//this.MenuInflater.Inflate(R.menu.activity_main, menu);
			return true;
		}

		public virtual bool OnNavigationItemSelected (int position, long id)
		{
			return false;
		}

		public override bool OnMenuItemSelected (int featureId, IMenuItem item)
		{
			switch (item.ItemId) {
			case Android.Resource.Id.Home:
				this.OnBackPressed ();
				return true;
			default:
				return base.OnMenuItemSelected (featureId, item);
			}
		}
	}
}

