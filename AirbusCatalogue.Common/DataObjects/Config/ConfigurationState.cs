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
    /// <summary>
    /// This class represents the diffrent states where a configuration and configurationGroup can reach.
    /// It is used for showing icons and texts on view. 
    /// </summary>
    [DataContract]
    public class ConfigurationState
    {
        public ConfigurationState(string readableName, string configuationStateText, string configuationStateIconValue, string configuationStateEditText)
        {
            ReadableName = readableName;
            ConfiguationStateText = configuationStateText;
            ConfiguationStateIconValue = configuationStateIconValue;
            ConfiguationStateEditText = configuationStateEditText;
        }

        public static readonly ConfigurationState IN_PROGRESS = new ConfigurationState("In Progress", "Configuration was ordered and is in progress.", "\uE15E", "show");

        public static readonly ConfigurationState ORDERED = new ConfigurationState("Ordered", "Configuration was ordered.", "\uE15E", "show");

        public static readonly ConfigurationState DELIVERED = new ConfigurationState("Delivered", "Configuration was build and has been delivered.", "\uE081", "show");

        public static readonly ConfigurationState IMPOSSIBLE = new ConfigurationState("Impossible", "No solution for current configuration is possible.", "\uE0C7", "remove group");

        public static readonly ConfigurationState VALID = new ConfigurationState("Valid", "Configuration is valid and can be ordered", "\uE081", "show");

        public static readonly ConfigurationState ALTERNATIVE = new ConfigurationState("Not configured", "There are alternatives available for this solution.", "\uE15E", "configurate");

        public static readonly ConfigurationState UNKNOWN = new ConfigurationState("Unknown", "No Internet connection or nothing selected ", "\uE11B", "save configuration");

        [DataMember]
        public string ReadableName { get; set; }

        [DataMember]
        public string ConfiguationStateText { get; set; }

        [DataMember]
        public string ConfiguationStateIconValue { get; set; }

        [DataMember]
        public string ConfiguationStateEditText { get; set; }

        [IgnoreDataMember]
        public Brush ConfiguationStateColor
        {
            get
            {
                return ConfigurationColorMapper.GetColorByState(this);
            }
        }
    }
}
