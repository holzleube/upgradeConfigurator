using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AirbusCatalogue.Model.File
{
    [DataContract]
    public class Dummy: IDummy
    {
        public Dummy(string test)
        {
            Name = test;
        }
        [DataMember]
        public string Name
        {
            get;
            set;
        }
    }
}
