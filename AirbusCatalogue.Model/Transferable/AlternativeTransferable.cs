using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AirbusCatalogue.Model.Transferable
{

    [DataContract]
    public class AlternativeTransferable
    {
        [DataMember]
        public string[] epacTdus
        {
            get;
            set;
        }
    }
}
