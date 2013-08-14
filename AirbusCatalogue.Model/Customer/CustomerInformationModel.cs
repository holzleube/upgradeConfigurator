using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.Common.DataObjects.Aircrafts;
using AirbusCatalogue.Common.DataObjects.Config;
using AirbusCatalogue.Common.DataObjects.Upgrades;
using AirbusCatalogue.Model.Aircrafts;
using AirbusCatalogue.Model.ConfigurationData;
using AirbusCatalogue.Model.Repository;
using AirbusCatalogue.Model.Templates;
using AirbusCatalogue.Model.Upgrades;
using GalaSoft.MvvmLight.Ioc;

namespace AirbusCatalogue.Model.Customer
{
    /// <summary>
    /// This model provides customer data for start page. 
    /// </summary>
    public class CustomerInformationModel
    {
   
        private const string BASE_PATH = "Assets/aircrafts/";
        private const string BASE_PATH_AIRCRAFT = "Assets/slider/";
        private const string A321Image = "Assets/allTypes/head_a321.png"; 
        private UpgradeRepository _upgradeRepository = new UpgradeRepository();
        public CustomerInformationModel()
        {
            if (! SimpleIoc.Default.IsRegistered<IConfiguration>())
            {
                var configuration = new Configuration("id", new List<IUpgradeItem>(), new List<IAircraft>(),
                                                      System.DateTime.Now.ToString(), ConfigurationState.IN_PROGRESS, null);
                SimpleIoc.Default.Register<IConfiguration>(() => configuration);
            }
        }

        public CustomerInformation GetCustomerInformationById(string uniqueId)
        {
            var lastConfiguration = new List<Configuration>();
            var newUpgrades = new List<IUpgradeItem>();
            var customerLogo = "Assets/customers/" + uniqueId + ".png";
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
                    _upgradeRepository.GetUpgradeItemById("al"),
                    _upgradeRepository.GetUpgradeItemById("bt"),
                    _upgradeRepository.GetUpgradeItemById("isisId")
                };
        }

        private List<Configuration> GetConfigurationForAirFrance()
        {
            var aircraftRepo = new AircraftRepository();
            var aircrafts = new List<IAircraft>
                {
                    aircraftRepo.GetAircraftByMSN("N-0001"), 
                    aircraftRepo.GetAircraftByMSN("N-0002"), 
                    aircraftRepo.GetAircraftByMSN("N-0003"), 
                    aircraftRepo.GetAircraftByMSN("N-0004") 
                };
            var upgrades = GetUpgradeItems();
            var programms = new List<IAircraftProgramm>()
                {
                    new AircraftProgramm("N-Series", "A320-Family", BASE_PATH_AIRCRAFT + "slider_a320.png"),
                    new AircraftProgramm("L-Series", "A330/A340", BASE_PATH_AIRCRAFT + "slider_a330.png"),
                    new AircraftProgramm("P-Series", "A350", BASE_PATH_AIRCRAFT + "slider_a350.png"),
                    new AircraftProgramm("R-Series", "A380", BASE_PATH_AIRCRAFT + "slider_a380.png")
                    
                };
            var lastConfigurations = new List<ConfigurationData.Configuration>
                {
                    new Configuration("configuration1",upgrades, aircrafts, "16.03.2013", ConfigurationState.IN_PROGRESS, programms[2]),
                    new Configuration("configuration2",upgrades, aircrafts, "16.01.2013",ConfigurationState.IN_PROGRESS, programms[0]),
                    new Configuration("configuration3",upgrades, aircrafts,  "13.03.2012", ConfigurationState.DELIVERED, programms[0]),
                    new Configuration("configuration4",upgrades, aircrafts,  "11.09.2010",ConfigurationState.DELIVERED,  programms[0]),
                    new Configuration("configuration5",upgrades, aircrafts,  "08.03.2010",ConfigurationState.DELIVERED,  programms[3]),
                    new Configuration("configuration6",upgrades, aircrafts,  "01.08.2009",ConfigurationState.DELIVERED,  programms[3])
                };
            return lastConfigurations;
        }

        private static List<IUpgradeItem> GetUpgradeItems()
        {
            var upgradeRepo = new UpgradeRepository();
            return new List<IUpgradeItem>()
                {
                    upgradeRepo.GetUpgradeItemById("1046GT2106"),
                    upgradeRepo.GetUpgradeItemById("1046GT2107"),
                    upgradeRepo.GetUpgradeItemById("1046GT2109")
                };
        }

        public CustomerInformation GetLastCustomerInformation()
        {
            return GetCustomerInformationById("emirates");
        }
    }
}
