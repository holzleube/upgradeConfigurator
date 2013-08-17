using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.Common.DataObjects.Customers;

namespace AirbusCatalogue.Model.Repository
{
    public interface ICustomerRepository
    {
        ICustomer GetCustomerById(string customerId);

        List<ICustomer> GetAllCustomers();
    }
}
