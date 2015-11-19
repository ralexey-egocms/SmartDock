using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.WindowsPhone.Views;
using SmartDocTestApp.Core.ViewModels;
using SmartDocTestApp.Phone.Converters;

namespace SmartDocTestApp.Phone.Views
{
    public partial class MenuView : MvxPhonePage, IMvxBindingContextOwner
    {
        public MenuView()
        {
            InitializeComponent();

            var set = this.CreateBindingSet<MenuView, MenuViewModel>();
            set.Bind(customIndeterminateProgressBar).For(x => x.Visibility).To(vm => vm.IsLoading).WithConversion(new ProgressBarVisibilityConverter(), null);
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

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            base.OnBackKeyPress(e);
        }
    }
}