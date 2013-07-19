using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.Common.DataObjects.Config;
using AirbusCatalogue.Common.DataObjects.Upgrades;
using AirbusCatalogue.ViewModel.ViewInterfaces.Configuration;

namespace AirbusCatalogue.ViewModel.ViewDataElements.Configuration
{
    public class AlternativeDataItem:BasicDataItem
    {
        public AlternativeDataItem(IUpgradeAlternative configurationAlternative, DataGroup @group) : base(configurationAlternative.UniqueId, configurationAlternative.Name, "", @group, 55, 40)
        {
            UpgradeItems = configurationAlternative.UpgradeItems;
        }
        
        public List<IUpgradeItem> UpgradeItems { get; set; } 
    }
}
