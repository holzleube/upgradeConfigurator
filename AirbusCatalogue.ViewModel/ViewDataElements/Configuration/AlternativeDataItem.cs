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
        public AlternativeDataItem(IUpgradeAlternative configurationAlternative, DataGroup @group) : base(configurationAlternative.UniqueId, configurationAlternative.Name, "", @group, 55, 0)
        {
            UpgradeItems = configurationAlternative.UpgradeItems;
            UpgradeAlternative = configurationAlternative;
            SetRightColumnSpan(UpgradeItems.Count);
        }

        private void SetRightColumnSpan(int count)
        {
            var countWithoutFirstPage = count - 3;
            if (countWithoutFirstPage > 0)
            {
                var factor = countWithoutFirstPage / 2;
                ColSpan = factor * 20;
            }
            ColSpan += 40;
        }

        public IUpgradeAlternative UpgradeAlternative { get; set; }
        
        public List<IUpgradeItem> UpgradeItems { get; set; } 
    }
}
