using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.WindowsPhone.Views;
using SmartDocTestApp.Core.ViewModels;
using SmartDocTestApp.Phone.Converters;
using System.Windows;

namespace SmartDocTestApp.Phone.Views
{
    public partial class LoginView : MvxPhonePage, IMvxBindingContextOwner
    {
        public LoginView()
            : base()
        {
            InitializeComponent();

            var set = this.CreateBindingSet<LoginView, LoginViewModel>();
            set.Bind(customIndeterminateProgressBar).For(x => x.Visibility).To(vm => vm.IsLoading).WithConversion(new ProgressBarVisibilityConverter(), null);
            set.Bind(login_username).For(x => x.IsEnabled).To(vm => vm.IsLoading).WithConversion(new InvertBoolConverter(), null);
            set.Bind(login_password).For(x => x.IsEnabled).To(vm => vm.IsLoading).WithConversion(new InvertBoolConverter(), null);
            set.Bind(login_button).For(x => x.IsEnabled).To(vm => vm.IsLoading).WithConversion(new InvertBoolConverter(), null);
            set.Apply();
        }

        private IMvxBindingContext _mvxBindingContext;

        public IMvxBindingContext BindingContext
        {
            get
            {
                if (_mvxBindingContext == null)
                    _mvxBindingContext = new MvxBindingContext();

                return _mvxBindingContext;
            }
            set
            {
                _mvxBindingContext = value;
            }
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            BindingContext.DataContext = this.ViewModel;
        }
    }
}