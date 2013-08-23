using System.Runtime.Serialization;
using AirbusCatalogue.Common.DataObjects.Config;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace AirbusCatalogue.ViewModel.ViewDataElements.Configuration
{
    [KnownType(typeof(IConfiguration))]
    public class ConfigurationDataItem:BasicDataItem
    {
        private readonly IConfigurationFile _configuration;

        public ConfigurationDataItem(IConfigurationFile configuration, DataGroup @group)
            : base(configuration.UniqueId, configuration.ConfigurationDate, configuration.AircraftProgrammImage,  @group, 28, 25)
        {
            _configuration = configuration;
        }

        public IConfigurationFile Configuration
        {
            get { return _configuration; }
        }

        public string ItemsCount { get { return _configuration.UpgradeCount; } }

        public string AircraftCount { get { return _configuration.AircraftCount; } }

        public string State { get { return _configuration.State.ConfiguationStateIconValue; } }

        public Brush StateColor
        {
            get { return _configuration.State.ConfiguationStateColor; }
        }
    }
}
