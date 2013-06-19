using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AirbusCatalogue.Model.CustomerModel
{
    public class CustomerModel : ICustomerModel
    {
        private string BASE_PATH = "Assets/customers/";
        public ICollection<Customer> GetAllCustomers()
        {
            var allCustomers = new List<Customer>();
            var customer = new Customer("airChina", BASE_PATH + "airChina.jpg", "Air China", true);
            return allCustomers;
        }
    }
}
