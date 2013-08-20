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
        
        string ImagePath { get; set; }

        string CustomerName { get; set; }

        char CustomerChar { get; set; }
    }
}
