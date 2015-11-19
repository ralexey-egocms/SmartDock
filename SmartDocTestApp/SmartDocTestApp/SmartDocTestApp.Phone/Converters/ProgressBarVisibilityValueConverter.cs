using Cirrious.CrossCore.Converters;
using System.Windows;

namespace SmartDocTestApp.Phone.Converters
{
    public class ProgressBarVisibilityConverter : MvxValueConverter<bool, Visibility>
    {
        protected override Visibility Convert(bool value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}