using Cirrious.CrossCore;
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.BindingEx.WindowsShared;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.WindowsPhone.Platform;
using Microsoft.Phone.Controls;
using SmartDocTestApp.Core.Services.Interfaces;
using SmartDocTestApp.Phone.Services;

namespace SmartDocTestApp.Phone
{
    public class Setup : MvxPhoneSetup
    {
        public Setup(PhoneApplicationFrame rootFrame)
            : base(rootFrame)
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
            Mvx.RegisterSingleton<IPreferencesService>(new PreferencesService());

            var builder = new MvxWindowsBindingBuilder();
            builder.DoRegistration();
        }
    }
}