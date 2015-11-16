using Android.App;
using Android.Content.PM;
using Android.OS;
using Cirrious.MvvmCross.Droid.Views;
using Java.Util;
using SmartDocTestApp.Core.ViewModels;

namespace SmartDocTestApp.Droid
{
    [Activity(
        Label = "SmartDocTestApp.Droid"
        , MainLauncher = true
        , Icon = "@drawable/icon"
        , Theme = "@style/Theme.Splash"
        , NoHistory = true
        , ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashView : LocalSplashScreenActivity
    {
        public SplashView()
            : base(Resource.Layout.view_splash)
        {
        }

        public new SplashViewModel ViewModel
        {
            get { return (SplashViewModel)base.ViewModel; }
        }
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            this.ViewModel.Locale = Locale.Default.Language;
        }
    }
}