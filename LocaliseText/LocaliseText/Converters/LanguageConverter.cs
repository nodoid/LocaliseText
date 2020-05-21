using System;
using System.Globalization;
using Xamarin.Forms;

namespace LocaliseText.Converters
{
    public class LanguageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var prop = (string)parameter;
            if (string.IsNullOrEmpty(prop))
                return string.Empty;

            var rv = mvvm.Languages.Resource.ResourceManager.GetString(prop);

            return rv;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
