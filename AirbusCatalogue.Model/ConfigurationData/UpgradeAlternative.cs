using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.Common.DataObjects.Config;
using AirbusCatalogue.Common.DataObjects.Upgrades;

namespace AirbusCatalogue.Model.ConfigurationData
{
    public class UpgradeAlternative: IUpgradeAlternative
    {
        public UpgradeAlternative(IUpgradeItem alternative)
            : this(new List<IUpgradeItem>() { alternative })
        {
            
        }

        public UpgradeAlternative(List<IUpgradeItem> upgradeAlternatives)
        {
            UpgradeItems = upgradeAlternatives;
        }
        public string UniqueId { get; set; }
        public List<IUpgradeItem> UpgradeItems { get; set; }
    }
}
