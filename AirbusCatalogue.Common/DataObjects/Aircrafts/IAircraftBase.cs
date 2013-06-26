using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.Common.DataObjects.General;

namespace AirbusCatalogue.Common.DataObjects.Aircrafts
{
    public interface IAircraftBase:IIdentable
    {
        string Name { get; set; }

        string ImagePath { get; set; }
    }
}
