using Cirrious.CrossCore;
using Cirrious.CrossCore.IoC;
using Cirrious.MvvmCross.Localization;
//using Cirrious.MvvmCross.Plugins.JsonLocalisation;
using SmartDocTestApp.Core.Services;

namespace SmartDocTestApp.Core
{
    public class App : Cirrious.MvvmCross.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            InitializeText();
            RegisterAppStart<ViewModels.LoginViewModel>();
        }

        private void InitializeText()
        {
            //var builder = new TextProviderBuilder();

            //Mvx.RegisterSingleton<IMvxTextProviderBuilder>(builder);
            //Mvx.RegisterSingleton<IMvxTextProvider>(builder.TextProvider);
        }
    }
}