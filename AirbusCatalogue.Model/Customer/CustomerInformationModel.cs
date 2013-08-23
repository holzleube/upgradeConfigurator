using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.Common.DataObjects.Aircrafts;
using AirbusCatalogue.Common.DataObjects.Config;
using AirbusCatalogue.Common.DataObjects.Customers;
using AirbusCatalogue.Common.DataObjects.Upgrades;
using AirbusCatalogue.Model.Aircrafts;
using AirbusCatalogue.Model.ConfigurationData;
using AirbusCatalogue.Model.Repository;
using AirbusCatalogue.Model.Templates;
using AirbusCatalogue.Model.Upgrades;
using GalaSoft.MvvmLight.Ioc;
using AirbusCatalogue.Model.File;
using AirbusCatalogue.Model.Json;

namespace AirbusCatalogue.Model.Customer
{
    /// <summary>
    /// This model provides customer data for start page. 
    /// </summary>
    public class CustomerInformationModel
    {
       
        private IAircraftRepository _aircraftRepo;
        private IUpgradeRepository _upgradeRepo;
        private ICustomerRepository _customerRepo;
        private ICustomerConfigurationRespository _configurationRepo;
        private ConfigurationFileManager _configurationFileManager;

        public CustomerInformationModel()
        {
            _aircraftRepo = SimpleIoc.Default.GetInstance<IAircraftRepository>();
            _upgradeRepo = SimpleIoc.Default.GetInstance<IUpgradeRepository>();
            _customerRepo = SimpleIoc.Default.GetInstance<ICustomerRepository>();
            _configurationRepo= SimpleIoc.Default.GetInstance<ICustomerConfigurationRespository>();
            _configurationFileManager = new ConfigurationFileManager();
            if (! SimpleIoc.Default.IsRegistered<IConfiguration>()) 
            {
                var configuration = new Configuration("id", new List<IUpgradeItem>(), new List<IAircraft>(),
                                                      System.DateTime.Now.ToString(), ConfigurationState.IN_PROGRESS, null, _customerRepo.GetCustomerById("emirates"));
                SimpleIoc.Default.Register<IConfiguration>(() => configuration);
            }
        }

        public CustomerInformation GetCustomerInformationById(string uniqueId)
        {
            var customer = _customerRepo.GetCustomerById(uniqueId);
            var lastConfiguration = _configurationRepo.GetCurentConfigurationsByCustomerId(customer.UniqueId); 
            var newUpgrades = new List<IUpgradeItem>();
            var customerLogo = customer.ImagePath;
            if (uniqueId.Equals("emirates"))
            {
                newUpgrades = GetNewUpgrades();
                return new CustomerInformation(uniqueId, lastConfiguration, newUpgrades, customerLogo, "/Assets/customers/emiratesA380Front.jpg");
            }
            if (uniqueId.Equals("airFrance"))
            {
                newUpgrades = GetNewUpgrades();
                return new CustomerInformation(uniqueId, lastConfiguration, newUpgrades, "Assets/customers/airfrance_2.png", "/Assets/customers/startScreenAirFrance.jpg");
            }
            return new CustomerInformation(uniqueId, lastConfiguration, GetNewUpgrades(), customerLogo, "/Assets/customers/neutralAircraftFront.jpg");
        }

        private List<IUpgradeItem> GetNewUpgrades()
        {
            return new List<IUpgradeItem>()
                {
                    _upgradeRepo.GetUpgradeItemById("al"),
                    _upgradeRepo.GetUpgradeItemById("bt"),
                    _upgradeRepo.GetUpgradeItemById("isisId")
                };
        }

        private List<IUpgradeItem> GetUpgradeItems()
        {
            return new List<IUpgradeItem>()
                {
                    _upgradeRepo.GetUpgradeItemById("1046GT2106"),
                    _upgradeRepo.GetUpgradeItemById("1046GT2107"),
                    _upgradeRepo.GetUpgradeItemById("1046GT2109")
                };
        }

        public CustomerInformation GetLastCustomerInformation()
        {
            return GetCustomerInformationById("emirates");
        }

        public List<ICustomer> GetAllCustomers()
        {
            //var config = _configurationFileManager.GetConfigurationByDate("20.08.2013-18.08");
            //var configuration = config.Result;
            return _customerRepo.GetAllCustomers();

        }

        public void SetCustomer(ICustomer customer)
        {
            var configuration = SimpleIoc.Default.GetInstance<IConfiguration>();
            configuration.ConfigurationCustomer = customer;
        }
    }
}
