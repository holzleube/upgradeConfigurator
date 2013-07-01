using AirbusCatalogue.Common.DataObjects.Upgrades;
using AirbusCatalogue.Model.ConfigurationData;
using AirbusCatalogue.Model.Upgrades;

namespace AirbusCatalogue.ViewModel.ViewDataElements.Upgrades
{
    public class NewUpgradeDataItem: BasicDataItem
    {
        public NewUpgradeDataItem(IUpgradeItem upgradeItem, DataGroup @group, int rowSpan, int colSpan) : base(upgradeItem.UniqueId, upgradeItem.Name, upgradeItem.ProductImagePath,  @group, rowSpan, colSpan)
        {
            Priority = upgradeItem.Priority;
        }

        public int Priority { set; get; }

    }

   
}
