using Cirrious.MvvmCross.ViewModels;

namespace SmartDocTestApp.Core.ViewModels
{
    public class LoginViewModel 
		: BaseViewModel
    {
		private string _hello = "Hello MvvmCross";
        public string Hello
		{ 
			get { return _hello; }
			set { _hello = value; RaisePropertyChanged(() => Hello); }
		}
    }
}
