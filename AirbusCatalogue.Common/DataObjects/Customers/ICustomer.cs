using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.Common.DataObjects.General;

namespace AirbusCatalogue.Common.DataObjects.Customers
{
    public interface ICustomer:IIdentable
    {
        [DataMember]
        string ImagePath { get; set; }

        [DataMember]
        string CustomerName { get; set; }

        [DataMember]
        char CustomerChar { get; set; }
    }
}
