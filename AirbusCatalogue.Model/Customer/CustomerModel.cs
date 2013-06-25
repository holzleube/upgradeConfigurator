using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.Model.Customer;


namespace AirbusCatalogue.Model.CustomerModel
{
    /// <summary>
    /// This model provides Customer data for the select_customer page.
    /// </summary>
    public class CustomerModel : ICustomerModel
    {
        private const string BASE_PATH = "Assets/customers/";

        public ICollection<Customer.Customer> AllCustomers{
            get
            {
                var allCustomers = new List<Customer.Customer>();
                var customer = new Customer.Customer("airChina", BASE_PATH + "airChina.png", "Air China", false);
                allCustomers.Add(customer);
                customer = new Customer.Customer("airCanada", BASE_PATH + "airCanada.gif", "Air Canada", false);
                allCustomers.Add(customer);
                customer = new Customer.Customer("airFrance", BASE_PATH + "airFrance_2.png", "Air France", false);
                allCustomers.Add(customer);
                customer = new Customer.Customer("airIndia", BASE_PATH + "airIndia.png", "Air India", true);
                allCustomers.Add(customer);
                customer = new Customer.Customer("airHong", BASE_PATH + "airHong.png", "Air Hong Kong", true);
                allCustomers.Add(customer);
                customer = new Customer.Customer("airJamaica", BASE_PATH + "airJamaica.png", "Air Jamaica", false);
                allCustomers.Add(customer);
                customer = new Customer.Customer("americanAirlines", BASE_PATH + "americanAirlines.jpg", "Air China", false);
                allCustomers.Add(customer);
                customer = new Customer.Customer("austrianAirlines", BASE_PATH + "austrianAirline.jpg", "Austrian Airline", true);
                allCustomers.Add(customer);
                customer = new Customer.Customer("bangkokAirways", BASE_PATH + "bangkokAirways.jpg", "Bangkok Airways", true);
                allCustomers.Add(customer);
                customer = new Customer.Customer("britishAirways", BASE_PATH + "britishAirways.jpg", "British Airways", false);
                allCustomers.Add(customer);
                customer = new Customer.Customer("bulgariaAir", BASE_PATH + "bulgariaAir.gif", "Bulgaria Air", false);
                allCustomers.Add(customer);
                customer = new Customer.Customer("chinaEastern", BASE_PATH + "chinaEastern.jpg", "China Eastern", false);
                allCustomers.Add(customer);
                customer = new Customer.Customer("continental", BASE_PATH + "continentalAirlines.jpg", "Continental Airlines", false);
                allCustomers.Add(customer);
                customer = new Customer.Customer("condor", BASE_PATH + "condor.png", "Condor", false);
                allCustomers.Add(customer);
                customer = new Customer.Customer("delta", BASE_PATH + "deltaAirlines.jpg", "Delta Airlines", false);
                allCustomers.Add(customer);
                customer = new Customer.Customer("dragonair", BASE_PATH + "dragonAir.png", "Dragon Air", false);
                allCustomers.Add(customer);
                customer = new Customer.Customer("drukair", BASE_PATH + "drukair.png", "Drukair", false);
                allCustomers.Add(customer);
                customer = new Customer.Customer("easyjet", BASE_PATH + "easyjet.png", "EasyJet", false);
                allCustomers.Add(customer);
                customer = new Customer.Customer("egyptair", BASE_PATH + "egyptAir2.jpg", "Egypt Air", false);
                allCustomers.Add(customer);
                customer = new Customer.Customer("etihad", BASE_PATH + "etihadAirways.png", "Etihad", false);
                allCustomers.Add(customer);
                customer = new Customer.Customer("emirates", BASE_PATH + "emirates.png", "Emirates", false);
                allCustomers.Add(customer);
                customer = new Customer.Customer("iberia", BASE_PATH + "iberia.png", "Iberia", false);
                allCustomers.Add(customer);
                customer = new Customer.Customer("indonesiaAirAsia", BASE_PATH + "indonesiaAirAsia.png", "Indonesia Air Asia", true);
                allCustomers.Add(customer);
                customer = new Customer.Customer("iranAir", BASE_PATH + "iranAir.png", "Iran Air", false);
                allCustomers.Add(customer);
                customer = new Customer.Customer("omanAir", BASE_PATH + "omanAir.png", "OmanAir", false);
                allCustomers.Add(customer);
                customer = new Customer.Customer("thomasCook", BASE_PATH + "thomasCook.png", "Thomas Cook", true);
                allCustomers.Add(customer);
                customer = new Customer.Customer("turkish", BASE_PATH + "turkish.png", "Turkish Airlines", false);
                allCustomers.Add(customer);
                return allCustomers;
            }
        }
    }
}
