using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.Common.DataObjects.Aircrafts;
using AirbusCatalogue.Common.DataObjects.Config;
using AirbusCatalogue.Common.DataObjects.Upgrades;
using AirbusCatalogue.Model.ConfigurationData;
using AirbusCatalogue.Model.ConfigurationService;
using AirbusCatalogue.Model.Transferable;
using AirbusCatalogue.Model.Upgrades;
using GalaSoft.MvvmLight.Ioc;


namespace AirbusCatalogue.Model.Config
{
    public class ConfigurationModel
    {
        public IConfiguration GetCurrentConfiguration()
        {

            return GetConfiguration();
        }

        private static IConfiguration GetConfiguration()
        {
            return SimpleIoc.Default.GetInstance<IConfiguration>();
        }

        public async void CheckConfiguration()
        {
            var webserviceClient =
                new AirbusConfigurationWebServiceClient();

            try
            {
                var newResult = await webserviceClient.getAllScheduledUserjobsAsync();
                //var result = await webserviceClient.getConfigurationResultAsync(new string[] { "N-2213", "N-3065", "N-2228", "N-2456", "N-2716" },
                //                                                      "CN22.00.998-01");
             var result = await webserviceClient.getConfigurationResultAsync(new string[] { "R-0007", "R-0009", "R-0011", "R-0013", "R-0016" },
                                                                      "CR34.53.100-01");
                var transferable = GetConfigurationResultTransferable(result.getConfigurationResultReturn);
                var test = result.getConfigurationResultReturn;
            }
            catch (Exception e)
            {
                
            } 
        }

        private ConfigurationResultTransferable[] GetConfigurationResultTransferable(string json)
        {
            var _Bytes = Encoding.Unicode.GetBytes(json);
            using (MemoryStream _Stream = new MemoryStream(_Bytes))
            {
                var _Serializer = new DataContractJsonSerializer(typeof(ConfigurationResultTransferable[]));
                return (ConfigurationResultTransferable[])_Serializer.ReadObject(_Stream);
            }
        }

        public void SelectAlternativeInGroup(IConfigurationGroup configurationGroupToUpdate)
        {
            var configurationGroup = FindConfigurationGroupInConfiguration(configurationGroupToUpdate.UniqueId);
            configurationGroup.SelectedAlternative = configurationGroupToUpdate.SelectedAlternative;
            configurationGroup.GroupConfigurationState = ConfigurationState.VALID;
        }

        private IConfigurationGroup FindConfigurationGroupInConfiguration(string uniqueId)
        {
            foreach (var confGroup in GetConfiguration().ConfigurationGroups)
            {
                if (confGroup.UniqueId.Equals(uniqueId))
                {
                    return confGroup;
                }
            }
            return null;
        }

        public async Task<IConfiguration> ConfigureCurrentConfiguration()
        {
            CheckConfiguration();
            await Task.Delay(TimeSpan.FromSeconds(3));
            var config = SimpleIoc.Default.GetInstance<IConfiguration>();
            config.ConfigurationGroups.Clear();
            var newUpgrades = GetConfigurationItemByAtaAndTdu();
            config.HasConfigurationChanged = false;
            var upgrades = new List<IUpgradeAlternative>() {new UpgradeAlternative("Alternative 1",config.Upgrades)};
            var upgrades2 = new List<IUpgradeAlternative>() {new UpgradeAlternative("Alternative 1", config.Upgrades), new UpgradeAlternative("Alternative 2",newUpgrades)};
            ConfigurationGroup currentGroup = null;
            var counter = 0;
            foreach (var aircraft in config.SelectedAircrafts)
            {
                if (counter%3 == 0)
                {
                    var groupNumber = counter/3 + 1;
                    if (counter == 3)
                    {
                        currentGroup = new ConfigurationGroup("Group "+groupNumber, null, upgrades2, new List<IAircraft>(), "confGroup"+groupNumber);
                    }
                    else if (counter == 6)
                    {
                        currentGroup = new ConfigurationGroup("Group "+groupNumber, null, new List<IUpgradeAlternative>(), new List<IAircraft>(), "confGroup"+groupNumber);
                    }
                    else
                    {
                        currentGroup = new ConfigurationGroup("Group " + groupNumber, null, upgrades, new List<IAircraft>(), "confGroup" + groupNumber);
                    }
                    config.ConfigurationGroups.Add(currentGroup);
                }
                currentGroup.Aircrafts.Add(aircraft);
                counter++;
            }
            return config;
        }

        private List<IUpgradeItem> GetConfigurationItemByAtaAndTdu()
        {
            var result = new List<IUpgradeItem>();
            result.Add(new UpgradeItem("23.50.110.22", "Alternative Jack Panel", "Installation of ACP and jack panel in avionics compartment", "/Assets/upgrades/jackPanel.jpg","",22,0,false));
            result.Add(new UpgradeItem("23.50.110.23", "Alternative Jack Panel", "Installation of ACP for fourth occupant and ACP and jack panel in avionics compartment", "/Assets/upgrades/jackPanel.jpg", "", 22, 0, false));
            result.Add(new UpgradeItem("23.50.110.23", "Alternative Jack Panel", "Installation of ACP for fourth occupant and ACP and jack panel in avionics compartment", "/Assets/upgrades/jackPanel.jpg", "", 22, 0, false));
            return result;
        }
    }
}
