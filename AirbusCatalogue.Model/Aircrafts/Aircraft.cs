using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.Common.DataObjects.Aircrafts;

namespace AirbusCatalogue.Model.Aircrafts
{
    /// <summary>
    /// This is the model class for a single aircraft. It holds the necessary information
    /// about the aircraft for selecting in aircraft selection.
    /// </summary>
    [DataContract]
    public class Aircraft : AAircraftBase, IAircraft
    {
        public Aircraft(string uniqueId, string name, string imagePath, int msnNumber, string version, string aircraftType) : base(uniqueId, name, imagePath)
        {
            MsnNumber = msnNumber;
            Version = version;
            AircraftType = aircraftType;
        }

        [DataMember]
        public int MsnNumber { get; set; }

        [DataMember]
        public string Version { get; set; }

        [DataMember]
        public string AircraftType { get; set; }

    }
}
