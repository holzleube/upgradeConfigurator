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
        public string UniqueId { get; set; }
        public List<IUpgradeItem> UpgradeItems { get; set; }
    }
}
