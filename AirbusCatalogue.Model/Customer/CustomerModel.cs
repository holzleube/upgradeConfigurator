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
            var customer = new Customer("airChina", BASE_PATH + "airChina.png", "Air China", false);
            allCustomers.Add(customer);
            customer = new Customer("airCanada", BASE_PATH + "airCanada.gif", "Air Canada", false);
            allCustomers.Add(customer);
            customer = new Customer("airFrance", BASE_PATH + "airFrance_2.png", "Air France", false);
            allCustomers.Add(customer);
            customer = new Customer("airIndia", BASE_PATH + "airIndia.png", "Air India", true);
            allCustomers.Add(customer);
            customer = new Customer("airHong", BASE_PATH + "airHong.png", "Air Hong Kong", true);
            allCustomers.Add(customer);
            customer = new Customer("airJamaica", BASE_PATH + "airJamaica.png", "Air Jamaica", false);
            allCustomers.Add(customer);
            customer = new Customer("americanAirlines", BASE_PATH + "americanAirlines.jpg", "Air China", false);
            allCustomers.Add(customer);
            customer = new Customer("austrianAirlines", BASE_PATH + "austrianAirline.jpg", "Austrian Airline", true);
            allCustomers.Add(customer);
            customer = new Customer("bangkokAirways", BASE_PATH + "bangkokAirways.jpg", "Bangkok Airways", true);
            allCustomers.Add(customer);
            customer = new Customer("britishAirways", BASE_PATH + "britishAirways.jpg", "British Airways", false);
            allCustomers.Add(customer);
            customer = new Customer("bulgariaAir", BASE_PATH + "bulgariaAir.gif", "Bulgaria Air", false);
            allCustomers.Add(customer);
            return allCustomers;
        }
    }
}
