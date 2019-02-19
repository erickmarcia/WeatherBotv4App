using System;
using System.Globalization;

using WeatherBotv4App.Helpers;

using Xamarin.Forms;

namespace WeatherBotv4App.Converters
{
    public class UserAlignmentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var user = value.ToString();
            return user == Constants.BotUser 
                ? TextAlignment.End 
                : TextAlignment.Start;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
