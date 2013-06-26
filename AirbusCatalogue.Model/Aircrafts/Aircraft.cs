using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirbusCatalogue.Model.Aircrafts
{
    public class Aircraft : AAircraftBase
    {
        public Aircraft(string uniqueId, string name, string imagePath, string msnNumber, string version) : base(uniqueId, name, imagePath)
        {
            MsnNumber = msnNumber;
            Version = version;
        }

        public string MsnNumber { get; set; }

        public string Version { get; set; }
    }
}
