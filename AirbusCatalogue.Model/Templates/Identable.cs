using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirbusCatalogue.Model.Templates
{
    public class Identable
    {
        public Identable(string uniqueId)
        {
            UniqueId = uniqueId;
        }
        public string UniqueId { get; set; }
    }
}
