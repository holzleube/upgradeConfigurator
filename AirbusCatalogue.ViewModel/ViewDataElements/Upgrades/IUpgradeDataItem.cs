using AirbusCatalogue.Common.DataObjects.Upgrades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AirbusCatalogue.ViewModel.ViewDataElements.Upgrades
{
    public interface IUpgradeDataItem
    {
        IUpgradeItem DataItem { get; set; }
    }
}
