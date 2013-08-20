using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AirbusCatalogue.Model.File
{
    [DataContract]
    [KnownType(typeof(Dummy))]
    public class DummyObject
    {
        public DummyObject(List<IDummy> dummy)
        {
            Dummys = dummy;
        }

        [DataMember]
        public List<IDummy> Dummys { get; set; }
    }
}
