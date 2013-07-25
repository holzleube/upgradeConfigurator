using Windows.UI;
using Windows.UI.Xaml.Media;

namespace AirbusCatalogue.ViewModel.ViewDataElements.Configuration
{
    public class ConfigurationDataItem:BasicDataItem
    {
        private readonly Model.ConfigurationData.Configuration _configuration;

        public ConfigurationDataItem(Model.ConfigurationData.Configuration configuration, DataGroup @group)
            : base(configuration.UniqueId, configuration.ConfigurationDate, configuration.Programm.ImagePath,  @group, 28, 25)
        {
            _configuration = configuration;
        }

        public string ItemsCount { get { return "Items:   " + _configuration.Upgrades.Count; } }

        public string AircraftCount { get { return "SelectedAircrafts:   " + _configuration.Upgrades.Count; } }

        public string State { get { return _configuration.State.ReadableName; } }

        public Brush StateColor
        {
            get { return _configuration.State.ConfiguationStateColor; }
        }
    }
}
