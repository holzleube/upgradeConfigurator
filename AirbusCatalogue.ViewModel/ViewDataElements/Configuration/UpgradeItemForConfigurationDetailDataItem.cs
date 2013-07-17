using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.Common.DataObjects.Upgrades;

namespace AirbusCatalogue.ViewModel.ViewDataElements.Configuration
{
    public class UpgradeItemForConfigurationDetailDataItem: BasicDataItem
    {
        private IUpgradeItem _upgradeItem;

        public UpgradeItemForConfigurationDetailDataItem(IUpgradeItem upgradeItem, DataGroup @group) : base(upgradeItem.UniqueId, upgradeItem.Name, upgradeItem.ProductImagePath, @group, 55, 40)
        {
            _upgradeItem = upgradeItem;
        }

        public string ProductImagePath
        {
            get { return _upgradeItem.ProductImagePath; }
        }
        
        public string SellerImagePath
        {
            get { return _upgradeItem.SellerImagePath; }
        }
        
        public string Name
        {
            get { return _upgradeItem.Name; }
        }
        
        public bool IsDefault
        {
            get { return _upgradeItem.IsDefault; }
        }

        public string Description
        {
            get { return _upgradeItem.Description; }
        }
    }
}
