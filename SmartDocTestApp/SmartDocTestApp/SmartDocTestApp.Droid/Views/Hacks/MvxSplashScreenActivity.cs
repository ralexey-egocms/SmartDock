using System.Threading;
using Android.OS;
using Android.Views;
using Cirrious.CrossCore.IoC;
using Cirrious.MvvmCross.Droid.Platform;
using Cirrious.MvvmCross.Platform;
using Cirrious.MvvmCross.ViewModels;
using Android.App;
using Cirrious.MvvmCross.Droid.Views;
using Cirrious.CrossCore;
using System;

namespace SmartDocTestApp.Droid
{
    [Activity]
    public class LocalSplashScreenActivity :MvxActivity
          , IMvxAndroidSplashScreenActivity
    {
        private const int NoContent = 0;

        private readonly int _resourceId;

        protected LocalSplashScreenActivity(int resourceId = NoContent)
        {
            _resourceId = resourceId;
        }

        protected virtual void RequestWindowFeatures()
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
        }

        protected override void OnCreate(Bundle bundle)
        {
            RequestWindowFeatures();

            var setup = MvxAndroidSetupSingleton.EnsureSingletonAvailable(ApplicationContext);
            setup.InitializeFromSplashScreen(this);

            base.OnCreate(bundle);

            if (_resourceId != NoContent)
            {
                // Set our view from the "splash" layout resource
                // Be careful to use non-binding inflation
                var content = LayoutInflater.Inflate(_resourceId, null);
                SetContentView(content);
            }
        }

        private bool _isResumed;

        protected override void OnResume()
        {
            base.OnResume();
            _isResumed = true;
            var setup = MvxAndroidSetupSingleton.EnsureSingletonAvailable(ApplicationContext);
            setup.InitializeFromSplashScreen(this);
        }

        protected override void OnPause()
        {
            _isResumed = false;
            var setup = MvxAndroidSetupSingleton.EnsureSingletonAvailable(ApplicationContext);
            setup.RemoveSplashScreen(this);
            base.OnPause();
        }

        public virtual void InitializationComplete()
        {
            if (!_isResumed)
                return;

            TriggerFirstNavigate();
        }

        protected virtual void TriggerFirstNavigate()
        {
            var starter = Mvx.Resolve<IMvxAppStart>();
            starter.Start();
        }
    }
}