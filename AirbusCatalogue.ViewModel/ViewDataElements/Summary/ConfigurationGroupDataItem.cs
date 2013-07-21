using AirbusCatalogue.Common.DataObjects.Config;

namespace AirbusCatalogue.ViewModel.ViewDataElements.Summary
{
    public class ConfigurationGroupDataItem: BasicDataItem
    {
        private readonly IConfigurationGroup _configurationGroup;
        private int _configurationItemsCount;

        public ConfigurationGroupDataItem(IConfigurationGroup configurationGroup, DataGroup @group, int configurationItemsCount)
            : base(configurationGroup.UniqueId, configurationGroup.Name, "", @group, 55, 40)
        {
            ConfigurationState = configurationGroup.GroupConfigurationState;
            _configurationGroup = configurationGroup;
            _configurationItemsCount = configurationItemsCount;
        }

        public IConfigurationGroup ConfigurationGroup
        {
            get { return _configurationGroup; }
        }

        public ConfigurationState ConfigurationState { get; set; }

        public string UpgradeCount{get { return "count: " + GetUpgradeItemsCount(); }}

        private int GetUpgradeItemsCount()
        {
            if (_configurationGroup.SelectedAlternative == null)
            {
                return _configurationItemsCount;
            }
            return _configurationItemsCount + _configurationGroup.SelectedAlternative.UpgradeItems.Count;
        }

        public string AircraftCount{get { return "count: " + _configurationGroup.Aircrafts.Count; }}
    }
}
