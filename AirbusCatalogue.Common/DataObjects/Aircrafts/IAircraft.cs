using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.Common.DataObjects.General;

namespace AirbusCatalogue.Common.DataObjects.Aircrafts
{
    public interface IAircraft: IAircraftBase
    {
        int MsnNumber { get; set; }

        string Version { get; set; }

        string AircraftType { get; set; }
    }
}
