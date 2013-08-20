using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.Model.Templates;
using AirbusCatalogue.Common.DataObjects.General;

namespace AirbusCatalogue.Model.Aircrafts
{
    [DataContract]
    public abstract class AAircraftBase:IIdentable
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
