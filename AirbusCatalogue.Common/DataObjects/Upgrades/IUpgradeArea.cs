using AirbusCatalogue.Common.DataObjects.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AirbusCatalogue.Model.Upgrades
{
    public interface IUpgradeArea: IIdentable, INameable
    {
        int ColSpan { get; set; }

        string ImagePath { get; set; }
    }
}
