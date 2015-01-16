using System;
using System.Globalization;
using Xamarin.Forms;

namespace FormsExample.ValueConverter
{
    public class MultiplyValueConverter : IValueConverter
    {
        public object Convert( object value, Type targetType, object parameter, CultureInfo culture )
        {
            var multiplier = int.Parse( parameter != null ? parameter.ToString() : "0" );
            int intValue;
            if ( value != null && int.TryParse( value.ToString(), out intValue ) )
            {
                return intValue * multiplier;
            }
            return "-";
        }

        public object ConvertBack( object value, Type targetType, object parameter, CultureInfo culture )
        {
            throw new NotImplementedException();
        }
    }
}