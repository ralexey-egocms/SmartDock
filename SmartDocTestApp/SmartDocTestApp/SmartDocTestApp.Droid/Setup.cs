using Android.Content;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.Droid.Platform;
using Cirrious.MvvmCross.ViewModels;
using SmartDocTestApp;
using SmartDocTestApp.Core.Services.Interfaces;
using SmartDocTestApp.Droid.Services;

namespace SmartDocTestApp.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }
		
        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }

        protected override void InitializeLastChance()
        {
            base.InitializeLastChance();
            Mvx.RegisterSingleton<ICurrentStateService>(new CurrentStateService());
        }

        protected override void InitializeFirstChance()
        {
            base.InitializeFirstChance();
        }
    }
}