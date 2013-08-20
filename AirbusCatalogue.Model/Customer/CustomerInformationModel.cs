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
        private const string BASE_PATH_AIRCRAFT = "Assets/slider/";
        private IAircraftRepository _aircraftRepo;
        private IUpgradeRepository _upgradeRepo;
        private ICustomerRepository _customerRepo;
        private ConfigurationFileManager _configurationFileManager;

        public CustomerInformationModel()
        {
            _aircraftRepo = SimpleIoc.Default.GetInstance<IAircraftRepository>();
            _upgradeRepo = SimpleIoc.Default.GetInstance<IUpgradeRepository>();
            _customerRepo = SimpleIoc.Default.GetInstance<ICustomerRepository>();
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
            var lastConfiguration = new List<IConfiguration>();
            var newUpgrades = new List<IUpgradeItem>();
            var customerLogo = customer.ImagePath;
            if (uniqueId.Equals("emirates"))
            {
                newUpgrades = GetNewUpgrades();
                lastConfiguration = GetConfigurationForAirFrance();
                return new CustomerInformation(uniqueId, lastConfiguration, newUpgrades, customerLogo, "/Assets/customers/emiratesA380Front.jpg");
            }
            if (uniqueId.Equals("airFrance"))
            {
                newUpgrades = GetNewUpgrades();
                lastConfiguration = GetConfigurationForAirFrance();
                return new CustomerInformation(uniqueId, lastConfiguration, newUpgrades, "Assets/customers/airfrance_2.png", "/Assets/customers/startScreenAirFrance.jpg");
            }
            return new CustomerInformation(uniqueId, GetConfigurationForAirFrance(), GetNewUpgrades(), customerLogo, "/Assets/customers/neutralAircraftFront.jpg");
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

        private List<IConfiguration> GetConfigurationForAirFrance()
        {
            var customer = _customerRepo.GetCustomerById("emirates");
            var aircrafts = new List<IAircraft>
                {
                    _aircraftRepo.GetAircraftByMSN("N-0002"), 
                    _aircraftRepo.GetAircraftByMSN("N-0005"), 
                    _aircraftRepo.GetAircraftByMSN("N-0007"), 
                    _aircraftRepo.GetAircraftByMSN("N-0009") 
                };
            var upgrades = GetUpgradeItems();
            var programms = new List<IAircraftProgramm>()
                {
                    new AircraftProgramm("N-Series", "A320-Family", BASE_PATH_AIRCRAFT + "slider_a320.png"),
                    new AircraftProgramm("L-Series", "A330/A340", BASE_PATH_AIRCRAFT + "slider_a330.png"),
                    new AircraftProgramm("P-Series", "A350", BASE_PATH_AIRCRAFT + "slider_a350.png"),
                    new AircraftProgramm("R-Series", "A380", BASE_PATH_AIRCRAFT + "slider_a380.png")
                    
                };
            
            var lastConfigurations = new List<IConfiguration>
                {
                    new Configuration("configuration1",upgrades, aircrafts, "16.03.2013", ConfigurationState.IN_PROGRESS, programms[2], customer),
                    new Configuration("configuration2",upgrades, aircrafts, "16.01.2013",ConfigurationState.IN_PROGRESS, programms[0], customer),
                    new Configuration("configuration3",upgrades, aircrafts,  "13.03.2012", ConfigurationState.DELIVERED, programms[0], customer),
                    new Configuration("configuration4",upgrades, aircrafts,  "11.09.2010",ConfigurationState.DELIVERED,  programms[0], customer),
                    new Configuration("configuration5",upgrades, aircrafts,  "08.03.2010",ConfigurationState.DELIVERED,  programms[3], customer),
                    new Configuration("configuration6",upgrades, aircrafts,  "01.08.2009",ConfigurationState.DELIVERED,  programms[3], customer)
                };
            return lastConfigurations;
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
            var config = _configurationFileManager.GetConfigurationByDate("20.08.2013-18.08");
            var configuration = config.Result;
            return _customerRepo.GetAllCustomers();

        }

        public void SetCustomer(ICustomer customer)
        {
            var configuration = SimpleIoc.Default.GetInstance<IConfiguration>();
            configuration.ConfigurationCustomer = customer;
        }
    }
}
