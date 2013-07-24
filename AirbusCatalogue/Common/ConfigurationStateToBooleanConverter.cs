using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using AirbusCatalogue.Common.DataObjects.Config;

namespace AirbusCatalogue.Common
{
    public sealed class ConfigurationStateToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var state = value as ConfigurationState;
            if (state == null)
            {
                return false;
            }
            if (parameter.Equals("refresh"))
            {
                if (state.Equals(ConfigurationState.UNKNOWN))
                {
                    return Visibility.Visible;
                }
                return Visibility.Collapsed;
            }
            if (parameter.Equals("save"))
            {
                return state.Equals(ConfigurationState.UNKNOWN) || state.Equals(ConfigurationState.ALTERNATIVE) || state.Equals(ConfigurationState.VALID);
            }
            if (parameter.Equals("order"))
            {
                return state.Equals(ConfigurationState.VALID);
            }
            if (parameter.Equals("appbar"))
            {
                if (state.Equals(ConfigurationState.VALID) || state.Equals(ConfigurationState.UNKNOWN) ||
                    state.Equals(ConfigurationState.ALTERNATIVE))
                {
                    return Visibility.Visible;
                }
                return Visibility.Collapsed;
            }
            
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value is Visibility && (Visibility)value == Visibility.Visible;
        }
    }
}
