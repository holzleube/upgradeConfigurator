using AirbusCatalogue.Common.DataObjects.Upgrades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirbusCatalogue.Model.Repository
{
    public interface IUpgradeRepository
    {
        IUpgradeItem GetUpgradeItemById(string uniqueId);
    }
}
