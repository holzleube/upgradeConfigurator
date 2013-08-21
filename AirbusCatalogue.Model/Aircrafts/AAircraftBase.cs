using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.Model.Templates;
using AirbusCatalogue.Common.DataObjects.General;
using AirbusCatalogue.Common.DataObjects.Aircrafts;

namespace AirbusCatalogue.Model.Aircrafts
{
    /// <summary>
    /// This Model class is a super class for all aircraft elements. Currently it is used from
    /// aircrafts and aircraftProgramm.
    /// </summary>
    [DataContract]
    public abstract class AAircraftBase:IIdentable, IAircraftBase
    {
        protected AAircraftBase(string uniqueId, string name, string imagePath)
            
        {
            Name = name;
            ImagePath = imagePath;
            UniqueId = uniqueId;
        }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string ImagePath { get; set; }

        [DataMember]
        public string UniqueId { get; set; }
    }
}
