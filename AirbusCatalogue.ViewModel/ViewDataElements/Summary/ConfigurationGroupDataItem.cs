using AirbusCatalogue.Common.DataObjects.Config;

namespace AirbusCatalogue.ViewModel.ViewDataElements.Summary
{
    public class ConfigurationGroupDataItem: BasicDataItem
    {
        public ConfigurationGroupDataItem(IConfigurationGroup configurationGroup, DataGroup @group)
            : base(configurationGroup.UniqueId, configurationGroup.Name, "", @group, 55, 40)
        {
        }
    }
}
