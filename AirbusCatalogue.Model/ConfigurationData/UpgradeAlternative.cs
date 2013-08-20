using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;
using AirbusCatalogue.Common.DataObjects.Config;
using AirbusCatalogue.Common.DataObjects.Upgrades;
using System.Runtime.Serialization;
using AirbusCatalogue.Model.Upgrades;

namespace AirbusCatalogue.Model.ConfigurationData
{
    [DataContract]
    [KnownType(typeof(UpgradeItem))]
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
        [DataMember]
        public string UniqueId { get; set; }
        [DataMember]
        public List<IUpgradeItem> UpgradeItems { get; set; }
        [DataMember]
        public string Name { get; set; }
    }
}
