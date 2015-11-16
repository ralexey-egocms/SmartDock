using Android.App;
using Android.Content.PM;
using Android.OS;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Droid.Views;
using Java.Util;
using SmartDocTestApp.Core.Services.Interfaces;
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
    public class SplashView : MvxSplashScreenActivity
    {
        public SplashView()
            : base(Resource.Layout.view_splash)
        {
        }

        //public new SplashViewModel ViewModel
        //{
        //    get { return (SplashViewModel)base.ViewModel; }
        //}
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Mvx.Resolve<ICurrentStateService>().SetupTextProvider(Locale.Default.Language);
        }
    }
}