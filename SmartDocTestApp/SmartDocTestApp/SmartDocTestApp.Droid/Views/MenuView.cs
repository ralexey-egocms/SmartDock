using Android.App;
using Android.OS;
using Cirrious.MvvmCross.Droid.Views;

namespace SmartDocTestApp.Droid.Views
{
    [Activity(Label = "View for FirstViewModel")]
    public class MenuView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.view_menu);
        }
    }
}