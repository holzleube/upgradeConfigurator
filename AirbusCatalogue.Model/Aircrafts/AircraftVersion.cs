using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirbusCatalogue.Model.Aircrafts
{
    public class AircraftVersion: AAircraftBase
    {
        public AircraftVersion(string uniqueId, string name) : base(uniqueId, name, "")
        {
        }

        public List<Aircraft> Aircrafts { get; set; } 
    }
}
