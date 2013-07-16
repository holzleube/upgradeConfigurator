using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using AirbusCatalogue.Common.DataObjects.Aircrafts;
using AirbusCatalogue.Common.DataObjects.Config;
using AirbusCatalogue.Model.AirbusConfigurationService;
using AirbusCatalogue.Model.ConfigurationData;
using GalaSoft.MvvmLight.Ioc;


namespace AirbusCatalogue.Model.Config
{
    public class ConfigurationModel
    {
        public IConfiguration GetCurrentConfiguration()
        {
            CheckConfiguration();
            return SimpleIoc.Default.GetInstance<IConfiguration>();
        }

        public async void CheckConfiguration()
        {
            var webserviceClient =
                new AirbusConfigurationWebServiceClient();

            try
            {
                var newResult = await webserviceClient.getAllScheduledUserjobsAsync();
                var result = await webserviceClient.getConfigurationResultAsync(new string[] { "N-2213", "N-3065", "N-2228", "N-2456", "N-2716" },
                                                                      "CN22.00.998-01");
             
                var test = result.getConfigurationResultReturn;
            }
            catch (Exception e)
            {
                
            } 
        }

        public async Task<IConfiguration> ConfigureCurrentConfiguration()
        {
            await Task.Delay(TimeSpan.FromSeconds(3));
            var config = SimpleIoc.Default.GetInstance<IConfiguration>();
            config.ConfigurationGroups.Clear();
            config.HasConfigurationChanged = false;
            var upgrades = new List<IUpgradeAlternative>() {new UpgradeAlternative(config.Upgrades)};
            ConfigurationGroup currentGroup = null;
            var counter = 0;
            foreach (var aircraft in config.SelectedAircrafts)
            {
                if (counter%3 == 0)
                {
                    int groupNumber = counter/3 + 1;
                    currentGroup = new ConfigurationGroup("Group "+groupNumber, null, upgrades, new List<IAircraft>(), "confGroup"+groupNumber);
                    config.ConfigurationGroups.Add(currentGroup);
                }
                currentGroup.Aircrafts.Add(aircraft);
                counter++;
            }
            return config;
        }
    }
}
