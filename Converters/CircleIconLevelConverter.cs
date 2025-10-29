using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastQuizMAUI.Converters
{
    class CircleIconLevelConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if(value is int level)
            {
                if (level == 0)
                {
                    return "white_circle.svg";
                }
                else if (level > 0 && level <= 5)
                {
                    return "red_circle.svg";
                }
                else if (level > 5 && level <= 10)
                {
                    return "orange_circle.svg";
                }
                else
                {
                    return "green_circle.svg";
                }
            }
            else
            {
                return "white_circle.svg";
            }
            
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
