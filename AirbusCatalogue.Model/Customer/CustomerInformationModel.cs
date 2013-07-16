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
            var newUpgrades = new List<UpgradeItem>();
            var customerLogo = "Assets/customers/" + uniqueId + ".png";
            if (uniqueId.Equals("emirates"))
            {
                newUpgrades = GetNewUpgrades();
                lastConfiguration = GetConfigurationForAirFrance();
                return new CustomerInformation(uniqueId, lastConfiguration, newUpgrades, customerLogo, "Assets/customers/emiratesA380.jpg");
            }
            if (uniqueId.Equals("airFrance"))
            {
                newUpgrades = GetNewUpgrades();
                lastConfiguration = GetConfigurationForAirFrance();
                return new CustomerInformation(uniqueId, lastConfiguration, newUpgrades, "Assets/customers/airfrance_2.png", "Assets/customers/startScreenAirFrance.jpg");
            }
            return new CustomerInformation(uniqueId, lastConfiguration, newUpgrades, customerLogo, "");
        }

        private List<UpgradeItem> GetNewUpgrades()
        {
            return new List<UpgradeItem>()
                {
                    new UpgradeItem("al","Ambient Light","perfect Ambilight","Assets/upgrades/ambient.jpg","", 1,1, false),
                    new UpgradeItem("bt","bridgestone tyres","new bridgestone tyres","Assets/upgrades/bridgestone.jpg","", 3,0, false),
                    new UpgradeItem("isisId","isis display","the isis cockpit display","Assets/upgrades/isis.jpg","",3,0, false)
                };
        }

        private List<Configuration> GetConfigurationForAirFrance()
        {
            var aircrafts = new List<IAircraft>
                {
                    new Aircraft("N-001","MSN-001",BASE_PATH + "A318_transparent.png", "001", "AFR01", "A320"),
                    new Aircraft("N-001","MSN-001",BASE_PATH + "A318_transparent.png", "001", "AFR01", "A320"),
                    new Aircraft("N-001","MSN-001",BASE_PATH + "A318_transparent.png", "001", "AFR01", "A320"),
                    new Aircraft("N-001","MSN-001",BASE_PATH + "A318_transparent.png", "001", "AFR01", "A320")
                };
            var upgrades = GetUpgradeItems();
            var programms = new List<IAircraftProgramm>()
                {
                    new AircraftProgramm("a320", "A320", "Assets/aircrafts/a320_transparent.png"),
                    new AircraftProgramm("a330", "A330", "Assets/aircrafts/a330_transparent.png"),
                    new AircraftProgramm("a340", "A340", "Assets/aircrafts/a330_transparent.png"),
                    new AircraftProgramm("a380", "A380", "Assets/aircrafts/a380_transparent.gif")
                    
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
            return new List<IUpgradeItem>()
                {
                    new UpgradeItem("al","Ambient Light","perfect Ambilight","Assets/upgrades/ambient.jpg","", 10,1, false),
                    new UpgradeItem("bt","bridgestone tyres","new bridgestone tyres","Assets/upgrades/bridgestone.jpg","",24, 3, false),
                    new UpgradeItem("isisId","isis display","the isis cockpit display","Assets/upgrades/isis.jpg","",24,3, false)
                };
        }

        public CustomerInformation GetLastCustomerInformation()
        {
            return GetCustomerInformationById("emirates");
        }
    }
}
