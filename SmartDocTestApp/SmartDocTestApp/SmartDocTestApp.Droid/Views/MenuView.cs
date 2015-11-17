using Android.App;
using Android.OS;
using Cirrious.MvvmCross.Droid.Views;
using Android.Views;
using SmartDocTestApp.Core.ViewModels;

namespace SmartDocTestApp.Droid.Views
{
	[Activity]
	public class MenuView : BaseView
	{
		public new MenuViewModel ViewModel {
			get { return (MenuViewModel)base.ViewModel; }
		}

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.view_menu);
		}

		public override bool OnCreateOptionsMenu (IMenu menu)
		{
			MenuInflater m = this.MenuInflater;
			m.Inflate (Resource.Menu.menu_menuview, menu);
			IMenuItem item = menu.FindItem (Resource.Id.menu_menu_user);
			item.SetTitle (ViewModel.UserName);
			item = menu.FindItem (Resource.Id.menu_menu_settings);
			item.SetVisible (false);
			var v = base.OnCreateOptionsMenu (menu);
			this.Menu = menu;
			return v;
		}

		public override bool OnMenuItemSelected (int featureId, IMenuItem item)
		{
			switch (item.ItemId) {
			case Resource.Id.menu_menu_user:
				return true;
			case Resource.Id.menu_menu_logout:
				ViewModel.OnLogOutCommand.Execute ();
				return true;
			default:
				return base.OnMenuItemSelected (featureId, item);
			}

		}
	}
}