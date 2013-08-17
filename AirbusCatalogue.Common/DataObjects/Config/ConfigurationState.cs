using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace AirbusCatalogue.Common.DataObjects.Config
{
    [DataContract]
    public class ConfigurationState
    {
        public ConfigurationState(string readableName, string configuationStateText, string configuationStateIconValue, string configuationStateEditText, Brush configuationStateColor)
        {
            ReadableName = readableName;
            ConfiguationStateText = configuationStateText;
            ConfiguationStateIconValue = configuationStateIconValue;
            ConfiguationStateEditText = configuationStateEditText;
            ConfiguationStateColor = configuationStateColor;
        }

        public static readonly ConfigurationState IN_PROGRESS = new ConfigurationState("In Progress", "Configuration was ordered and is in progress.", "\uE15E", "show", new SolidColorBrush(Color.FromArgb(153, 255, 255, 0)));

        public static readonly ConfigurationState ORDERED = new ConfigurationState("Ordered", "Configuration was ordered.", "\uE15E", "show", new SolidColorBrush(Color.FromArgb(153, 255, 255, 0)));

        public static readonly ConfigurationState DELIVERED = new ConfigurationState("Delivered", "Configuration was build and has been delivered.", "\uE081", "show", new SolidColorBrush(Color.FromArgb(120, 0, 255, 0)));

        public static readonly ConfigurationState IMPOSSIBLE = new ConfigurationState("Impossible", "No solution for current configuration is possible.", "\uE0C7", "remove group", new SolidColorBrush(Color.FromArgb(153, 255, 0, 0)));

        public static readonly ConfigurationState VALID = new ConfigurationState("Valid", "Configuration is valid and can be ordered", "\uE081", "show", new SolidColorBrush(Color.FromArgb(120, 0, 255, 0)));

        public static readonly ConfigurationState ALTERNATIVE = new ConfigurationState("Not configured", "There are alternatives available for this solution.", "\uE15E", "configurate", new SolidColorBrush(Color.FromArgb(153, 255, 255, 0)));

        public static readonly ConfigurationState UNKNOWN = new ConfigurationState("Unknown", "No Internet connection or nothing selected ", "\uE11B", "save configuration", new SolidColorBrush(Color.FromArgb(153, 255, 255, 0)));

        [DataMember]
        public string ReadableName { get; set; }

        [DataMember]
        public string ConfiguationStateText { get; set; }

        [DataMember]
        public string ConfiguationStateIconValue { get; set; }

        [DataMember]
        public string ConfiguationStateEditText { get; set; }

        [DataMember]
        public Brush ConfiguationStateColor { get; set; }
    }
}
