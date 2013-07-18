using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;
using AirbusCatalogue.Common.DataObjects.Config;
using AirbusCatalogue.Common.DataObjects.Upgrades;

namespace AirbusCatalogue.Model.ConfigurationData
{
    public class UpgradeAlternative: IUpgradeAlternative
    {
        public UpgradeAlternative(string name, IUpgradeItem alternative)
            : this(name, new List<IUpgradeItem>() { alternative })
        {
            
        }

        public UpgradeAlternative(string name, List<IUpgradeItem> upgradeAlternatives)
        {
            UpgradeItems = upgradeAlternatives;
            Name = name;
        }
        public string UniqueId { get; set; }
        public List<IUpgradeItem> UpgradeItems { get; set; }
        public string Name { get; set; }
    }
}
