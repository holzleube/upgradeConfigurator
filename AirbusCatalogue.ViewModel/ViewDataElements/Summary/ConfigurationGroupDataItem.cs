using AirbusCatalogue.Common.DataObjects.Config;

namespace AirbusCatalogue.ViewModel.ViewDataElements.Summary
{
    public class ConfigurationGroupDataItem: BasicDataItem
    {
        private IConfigurationGroup _configurationGroup;

        public ConfigurationGroupDataItem(IConfigurationGroup configurationGroup, DataGroup @group)
            : base(configurationGroup.UniqueId, configurationGroup.Name, "", @group, 55, 40)
        {
            ConfigurationState = configurationGroup.GroupConfigurationState;
            _configurationGroup = configurationGroup;
        }

        public IConfigurationGroup ConfigurationGroup
        {
            get { return _configurationGroup; }
        }

        public ConfigurationState ConfigurationState { get; set; }

        public string UpgradeCount{get { return "count: " + GetUpgradeItemsCount(); }}

        private int GetUpgradeItemsCount()
        {
            if (_configurationGroup.Alternatives.Count == 0)
            {
                return 0;
            }
            return _configurationGroup.Alternatives[0].UpgradeItems.Count;
        }

        public string AircraftCount{get { return "count: " + _configurationGroup.Aircrafts.Count; }}
    }
}
