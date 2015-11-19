using Cirrious.MvvmCross.WindowsPhone.Views;

namespace SmartDocTestApp.Phone.Views
{
    public partial class MenuView : MvxPhonePage
    {
        public MenuView()
        {
            InitializeComponent();
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            base.OnBackKeyPress(e);
        }
    }
}