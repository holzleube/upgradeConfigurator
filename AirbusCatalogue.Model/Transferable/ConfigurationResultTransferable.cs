using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AirbusCatalogue.Model.Transferable
{
    [DataContract]
    public class ConfigurationResultTransferable
    {
        [DataMember]
        public string[] msnList
        {
            get;
            set;
        }

        [DataMember]
        public string[] mod
        {
            get;
            set;
        }

        [DataMember]
        public AlternativeTransferable[] alternatives
        {
            get;
            set;
        }
    }
}
