using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.Common.DataObjects.Upgrades;

namespace AirbusCatalogue.ViewModel.ViewDataElements.Upgrades
{
    public class NewUpgradeBigDataItem : BasicDataItem, IUpgradeDataItem
    {
        public NewUpgradeBigDataItem(IUpgradeItem upgradeItem, DataGroup @group)
            : base(upgradeItem.UniqueId, upgradeItem.Name, upgradeItem.ProductImagePath, @group, 35, 50)
        {
            DataItem = upgradeItem;
        }

        public IUpgradeItem DataItem
        {
            get;
            set;
        }
    }
}
