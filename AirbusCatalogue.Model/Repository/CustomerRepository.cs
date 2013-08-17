using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.Common.DataObjects.Customers;

namespace AirbusCatalogue.Model.Repository
{
    public class CustomerRepository:ICustomerRepository
    {
        private const string BASE_PATH = "/Assets/customers/";
        private Dictionary<string, ICustomer> _dataMap;

        public CustomerRepository()
        {
            _dataMap = new Dictionary<string, ICustomer>();
            InitializeDataMap();
        }

        private void InitializeDataMap()
        {
            _dataMap.Add("airChina", new Customer.Customer("airChina", BASE_PATH + "airChina.png", "Air China"));
            _dataMap.Add("airCanada",new Customer.Customer("airCanada", BASE_PATH + "airCanada.gif", "Air Canada"));
            _dataMap.Add("airFrance",new Customer.Customer("airFrance", BASE_PATH + "airFrance_2.png", "Air France"));
            _dataMap.Add("airIndia",new Customer.Customer("airIndia", BASE_PATH + "airIndia.png", "Air India"));
            _dataMap.Add("airHong",new Customer.Customer("airHong", BASE_PATH + "airHong.png", "Air Hong Kong"));
            _dataMap.Add("airJamaica",new Customer.Customer("airJamaica", BASE_PATH + "airJamaica.png", "Air Jamaica"));
            _dataMap.Add("americanAirlines",new Customer.Customer("americanAirlines", BASE_PATH + "americanAirlines.jpg", "Air China"));
            _dataMap.Add("austrianAirlines", new Customer.Customer("austrianAirlines", BASE_PATH + "austrianAirline.jpg", "Austrian Airline"));

            _dataMap.Add("bangkokAirways",new Customer.Customer("bangkokAirways", BASE_PATH + "bangkokAirways.jpg", "Bangkok Airways"));

            _dataMap.Add("britishAirways",new Customer.Customer("britishAirways", BASE_PATH + "britishAirways.jpg", "British Airways"));

            _dataMap.Add("bulgariaAir",new Customer.Customer("bulgariaAir", BASE_PATH + "bulgariaAir.gif", "Bulgaria Air"));

            _dataMap.Add("chinaEastern",new Customer.Customer("chinaEastern", BASE_PATH + "chinaEastern.jpg", "China Eastern"));

            _dataMap.Add("continental",new Customer.Customer("continental", BASE_PATH + "continentalAirlines.jpg", "Continental Airlines"));

            _dataMap.Add("condor",new Customer.Customer("condor", BASE_PATH + "condor.png", "Condor"));

            _dataMap.Add("delta",new Customer.Customer("delta", BASE_PATH + "delta.png", "Delta Airlines"));

            _dataMap.Add("dragonair",new Customer.Customer("dragonair", BASE_PATH + "dragonAir.png", "Dragon Air"));

            _dataMap.Add("drukair",new Customer.Customer("drukair", BASE_PATH + "drukair.png", "Drukair"));

            _dataMap.Add("easyjet",new Customer.Customer("easyjet", BASE_PATH + "easyjet.png", "EasyJet"));

            _dataMap.Add("egyptair",new Customer.Customer("egyptair", BASE_PATH + "egyptAir2.jpg", "Egypt Air"));

            _dataMap.Add("etihad",new Customer.Customer("etihad", BASE_PATH + "etihadAirways.png", "Etihad"));

            _dataMap.Add("emirates",new Customer.Customer("emirates", BASE_PATH + "emirates.png", "Emirates"));

            _dataMap.Add("iberia",new Customer.Customer("iberia", BASE_PATH + "iberia.png", "Iberia"));

            _dataMap.Add("indonesiaAirAsia",new Customer.Customer("indonesiaAirAsia", BASE_PATH + "indonesiaAirAsia.png", "Indonesia Air Asia"));

            _dataMap.Add("iranAir",new Customer.Customer("iranAir", BASE_PATH + "iranAir.png", "Iran Air"));

            _dataMap.Add("omanAir",new Customer.Customer("omanAir", BASE_PATH + "omanAir.png", "OmanAir"));

            _dataMap.Add("thomasCook", new Customer.Customer("thomasCook", BASE_PATH + "thomasCook.png", "Thomas Cook"));

            _dataMap.Add("turkish",new Customer.Customer("turkish", BASE_PATH + "turkish.png", "Turkish Airlines"));
        }

        public ICustomer GetCustomerById(string customerId)
        {
            return _dataMap[customerId];
        }

        public List<ICustomer> GetAllCustomers()
        {
            return _dataMap.Select(x => x.Value).ToList();
        }
    }
}
