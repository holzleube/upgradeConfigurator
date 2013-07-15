using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.Common.DataObjects.General;
using AirbusCatalogue.Common.DataObjects.Upgrades;

namespace AirbusCatalogue.Common.DataObjects.Config
{
    public interface IUpgradeAlternative: IIdentable
    {
        List<IUpgradeItem> UpgradeItems { get; set; } 
    }
}
