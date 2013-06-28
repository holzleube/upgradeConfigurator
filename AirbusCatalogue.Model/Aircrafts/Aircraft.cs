using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.Common.DataObjects.Aircrafts;

namespace AirbusCatalogue.Model.Aircrafts
{
    public class Aircraft : AAircraftBase, IAircraft
    {
        public Aircraft(string uniqueId, string name, string imagePath, string msnNumber, string version, string aircraftType) : base(uniqueId, name, imagePath)
        {
            MsnNumber = msnNumber;
            Version = version;
            AircraftType = aircraftType;
        }

        public string MsnNumber { get; set; }

        public string Version { get; set; }

        public string AircraftType { get; set; }

        public override bool Equals(object obj)
        {
            var aircraft = obj as Aircraft;
            if (aircraft != null)
            {
                return UniqueId.Equals(aircraft.UniqueId);
            }
            return base.Equals(obj);
        }

        
    }
}
