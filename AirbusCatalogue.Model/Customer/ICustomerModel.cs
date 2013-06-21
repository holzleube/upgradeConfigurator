using System.Collections.Generic;

namespace AirbusCatalogue.Model.Customer
{
    public interface ICustomerModel
    {
        ICollection<Customer> AllCustomers { get; }
    }
}
