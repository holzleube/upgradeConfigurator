using AirbusCatalogue.Common.DataObjects.Upgrades;
using AirbusCatalogue.Model.ConfigurationData;
using AirbusCatalogue.Model.Upgrades;

namespace AirbusCatalogue.ViewModel.ViewDataElements.Upgrades
{
    public class NewUpgradeSmallDataItem: BasicDataItem, IUpgradeDataItem

    {
        public NewUpgradeSmallDataItem(IUpgradeItem upgradeItem, DataGroup @group) : base(upgradeItem.UniqueId, upgradeItem.Name, upgradeItem.ProductImagePath,  @group, 20, 25)
        {
            Priority = upgradeItem.Priority;
            DataItem = upgradeItem;
        }

        public int Priority { set; get; }


        public IUpgradeItem DataItem
        {
            get;
            set;
        }
    }

   
}
