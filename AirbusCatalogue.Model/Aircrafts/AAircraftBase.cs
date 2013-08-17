using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.Model.Templates;

namespace AirbusCatalogue.Model.Aircrafts
{
    [DataContract]
    public abstract class AAircraftBase:Identable
    {
        protected AAircraftBase(string uniqueId, string name, string imagePath)
            : base(uniqueId)
        {
            Name = name;
            ImagePath = imagePath;
        }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string ImagePath { get; set; }
    }
}
