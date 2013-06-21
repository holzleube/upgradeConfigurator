using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.Model.Aircrafts;
using AirbusCatalogue.Model.ConfigurationData;

namespace AirbusCatalogue.Model.Customer
{
    /// <summary>
    /// This model provides customer data for start page. 
    /// </summary>
    public class CustomerInformationModel
    {
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
                    new UpgradeItem("al","Ambient Light","perfect Ambilight","Assets/upgrades/ambient.jpg", 1),
                    new UpgradeItem("bt","bridgestone tyres","new bridgestone tyres","Assets/upgrades/bridgestone.jpg", 3),
                    new UpgradeItem("isisId","isis display","the isis cockpit display","Assets/upgrades/isis.jpg",3)
                };
        }

        private List<Configuration> GetConfigurationForAirFrance()
        {
            var aircrafts = new List<Aircraft>
                {
                    new Aircraft(),
                    new Aircraft(),
                    new Aircraft(),
                    new Aircraft()
                };
            var upgrades = new List<UpgradeItem>()
                {
                    new UpgradeItem("al","Ambient Light","perfect Ambilight","Assets/upgrades/ambient.jpg", 1),
                    new UpgradeItem("bt","bridgestone tyres","new bridgestone tyres","Assets/upgrades/bridgestone.jpg", 3),
                    new UpgradeItem("isisId","isis display","the isis cockpit display","Assets/upgrades/isis.jpg",3)
                };
           
            var lastConfigurations = new List<Configuration>
                {
                    new Configuration("configuration1",upgrades, aircrafts, "Assets/aircrafts/a340_09.jpg", "16.03.2013", "In Progress"),
                    new Configuration("configuration2",upgrades, aircrafts, "Assets/aircrafts/a319.jpg", "16.01.2013","In Progress"),
                    new Configuration("configuration3",upgrades, aircrafts, "Assets/aircrafts/a320_long.jpg", "13.03.2012", "Delivered"),
                    new Configuration("configuration4",upgrades, aircrafts, "Assets/aircrafts/a380_sky.JPG", "11.09.2010","Delivered"),
                    new Configuration("configuration5",upgrades, aircrafts, "Assets/aircrafts/a380_sky.JPG", "08.03.2010","Delivered"),
                    new Configuration("configuration6",upgrades, aircrafts, "Assets/aircrafts/a330_2.jpg", "01.08.2009","Delivered")
                };
            return lastConfigurations;
        }
    }
}
