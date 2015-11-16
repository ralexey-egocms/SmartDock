using Cirrious.CrossCore;
//using Cirrious.MvvmCross.Plugins.JsonLocalisation;
using Cirrious.MvvmCross.ViewModels;

namespace SmartDocTestApp.Core.ViewModels
{
    public class SplashViewModel 
		: BaseViewModel
    {
        //readonly IMvxTextProviderBuilder _builder;

        //public SplashViewModel() {
        //    _builder = Mvx.Resolve<IMvxTextProviderBuilder>();
        //}


        void PickLanguage(string which)
        {
            //_builder.LoadResources(which);
        }


        private string _local = "en";
        public string Locale
		{ 
			get { return _local; }
			set { _local = value;
                PickLanguage(_local);
                RaisePropertyChanged(() => Locale); }
		}
    }
}
