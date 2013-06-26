using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirbusCatalogue.Common.DataObjects.Customers
{
    public interface ICustomer
    {
        string ImagePath { get; set; }

        string CustomerName { get; set; }

        bool IsTextVisible { get; set; }

        char CustomerChar { get; set; }
    }
}
