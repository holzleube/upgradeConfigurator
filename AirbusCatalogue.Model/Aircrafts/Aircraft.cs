using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.Common.DataObjects.Aircrafts;

namespace AirbusCatalogue.Model.Aircrafts
{
    [DataContract]
    public class Aircraft : AAircraftBase, IAircraft
    {
        public Aircraft(string uniqueId, string name, string imagePath, string msnNumber, string version, string aircraftType) : base(uniqueId, name, imagePath)
        {
            MsnNumber = msnNumber;
            Version = version;
            AircraftType = aircraftType;
        }

        [DataMember]
        public string MsnNumber { get; set; }

        [DataMember]
        public string Version { get; set; }

        [DataMember]
        public string AircraftType { get; set; }

    }
}
