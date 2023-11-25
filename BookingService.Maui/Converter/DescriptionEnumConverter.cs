using BookingService.Maui.Helpers;
using System.Globalization;

namespace BookingService.Maui.Converter
{
    public class DescriptionEnumConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.GetType().IsEnum)
            {
                Type enumType = value.GetType();
                Enum enumValue = (Enum)Enum.ToObject(enumType, value);
                return enumValue.GetDescription();
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
