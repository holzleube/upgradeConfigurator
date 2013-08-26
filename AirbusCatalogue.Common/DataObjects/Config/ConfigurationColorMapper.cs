using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace AirbusCatalogue.Common.DataObjects.Config
{
    /// <summary>
    /// This class maps the right configuration color to the configuration state.
    /// This is necessary for the serialization when loading a configuration file
    /// </summary>
    public class ConfigurationColorMapper
    {
        
        private static Dictionary<string, Brush> _colorMap;
        public static void InitializeMapIfNotDone()
        {
            if (_colorMap != null) return;
            _colorMap = new Dictionary<string, Brush>();
            _colorMap.Add(ConfigurationState.VALID.ReadableName, new SolidColorBrush(Color.FromArgb(120, 0, 255, 0)));
            _colorMap.Add(ConfigurationState.IN_PROGRESS.ReadableName, new SolidColorBrush(Color.FromArgb(153, 255, 255, 0)));
            _colorMap.Add(ConfigurationState.ORDERED.ReadableName, new SolidColorBrush(Color.FromArgb(153, 255, 255, 0)));
            _colorMap.Add(ConfigurationState.DELIVERED.ReadableName, new SolidColorBrush(Color.FromArgb(120, 0, 255, 0)));
            _colorMap.Add(ConfigurationState.IMPOSSIBLE.ReadableName, new SolidColorBrush(Color.FromArgb(153, 255, 0, 0)));
            _colorMap.Add(ConfigurationState.ALTERNATIVE.ReadableName, new SolidColorBrush(Color.FromArgb(153, 255, 255, 0)));
            _colorMap.Add(ConfigurationState.UNKNOWN.ReadableName, new SolidColorBrush(Color.FromArgb(153, 255, 255, 0)));
        }

        public static Brush GetColorByState(ConfigurationState state)
        {
            InitializeMapIfNotDone();
            return _colorMap[state.ReadableName];
        }

    }
}
