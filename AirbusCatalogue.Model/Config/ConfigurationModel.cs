using System;
using System.Collections.Generic;
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

        public IConfiguration ConfigureCurrentConfiguration()
        {
            var config = SimpleIoc.Default.GetInstance<IConfiguration>();
            config.ConfigurationGroups.Add(new ConfigurationGroup("Group 1",null, new List<IUpgradeAlternative>(),new List<IAircraft>(), "confGroup1" ));
            config.ConfigurationGroups.Add(new ConfigurationGroup("Group 2",null, new List<IUpgradeAlternative>(),new List<IAircraft>(), "confGroup1" ));
            return config;
        }
    }
}
