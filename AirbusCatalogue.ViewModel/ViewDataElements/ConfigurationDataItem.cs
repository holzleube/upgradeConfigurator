using AirbusCatalogue.Model.ConfigurationData;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace AirbusCatalogue.ViewModel.ViewDataElements
{
    public class ConfigurationDataItem:BasicDataItem
    {
        private readonly Configuration _configuration;

        public ConfigurationDataItem(Configuration configuration, DataGroup @group) : base(configuration.UniqueId, configuration.ConfigurationDate, configuration.AircraftImagePath, "",  @group, 20, 50)
        {
            _configuration = configuration;
        }

        public string ItemsCount { get { return "Items:   " + _configuration.Upgrades.Count; } }

        public string AircraftCount { get { return "Aircrafts:   " + _configuration.Upgrades.Count; } }

        public string State { get { return _configuration.State; } }

        public Brush StateColor
        {
            get
            {
                if (_configuration.State.Equals("In Progress"))
                {
                    return new SolidColorBrush(Color.FromArgb(200, 238, 238, 69));
                }
                return  new SolidColorBrush(Color.FromArgb(150,28,230,28));
            }
        }
    }
}
