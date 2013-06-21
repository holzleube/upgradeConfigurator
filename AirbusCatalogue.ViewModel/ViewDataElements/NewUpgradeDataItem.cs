using AirbusCatalogue.Model.ConfigurationData;

namespace AirbusCatalogue.ViewModel.ViewDataElements
{
    public class NewUpgradeDataItem: BasicDataItem
    {
        public NewUpgradeDataItem(UpgradeItem upgradeItem, DataGroup @group, int rowSpan, int colSpan) : base(upgradeItem.UniqueId, upgradeItem.Name, upgradeItem.ProductImagePath, upgradeItem.Description,  @group, rowSpan, colSpan)
        {
            Priority = upgradeItem.Priority;
        }

        public int Priority { set; get; }

    }

   
}
