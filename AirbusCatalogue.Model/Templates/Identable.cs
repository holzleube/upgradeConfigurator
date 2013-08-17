using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.Common.BasicData;
using AirbusCatalogue.Common.DataObjects.General;

namespace AirbusCatalogue.Model.Templates
{
    [DataContract]
    public class Identable: IIdentable
    {
        public Identable(string uniqueId)
        {
            UniqueId = uniqueId;
        }
        public string UniqueId { get; set; }
    }
}
