using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastQuizMAUI.Models;

namespace FastQuizMAUI.Converters
{
    class CircleIconLevelConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is ItemsBoxModel item)
            {
                if (!item.IsEnabled)
                {
                    return "disabled_circle.svg";
                }else if(item.Level < 30)
                {
                    return "red_circle.svg";
                }else if(item.Level >= 30 && item.Level < 70)
                {
                    return "orange_circle.svg";
                }
                else if(item.Level >= 70 && item.Level < 100)
                {
                    return "green_circle.svg";
                }
                else
                {
                    return "crown_level.svg";
                }
            }
            return null;

        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
