using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.Model.Templates;

namespace AirbusCatalogue.Model.Aircrafts
{
    public abstract class AAircraftBase:Identable
    {
        protected AAircraftBase(string uniqueId, string name, string imagePath)
            : base(uniqueId)
        {
            Name = name;
            ImagePath = imagePath;
        }

        public string Name { get; set; }

        public string ImagePath { get; set; }
    }
}
