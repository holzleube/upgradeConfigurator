using AirbusCatalogue.Model.ConfigurationData;

namespace AirbusCatalogue.ViewModel.ViewDataElements.Upgrades
{
    public class NewUpgradeDataItem: BasicDataItem
    {
        public NewUpgradeDataItem(UpgradeItem upgradeItem, DataGroup @group, int rowSpan, int colSpan) : base(upgradeItem.UniqueId, upgradeItem.Name, upgradeItem.ProductImagePath,  @group, rowSpan, colSpan)
        {
            Priority = upgradeItem.Priority;
        }

        public int Priority { set; get; }

    }

   
}
