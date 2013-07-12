using System;
using System.ServiceModel;
using AirbusCatalogue.Common.DataObjects.Config;
using AirbusCatalogue.Model.AirbusConfigurationService;
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
                var result = await webserviceClient.getConfigurationResultAsync(new string[] { "N-2213", "N-3065", "N-2228", "N-2456", "N-2716" },
                                                                      "CN22.00.998-01");
                var test = result.getConfigurationResultReturn;
            }
            catch (Exception e)
            {
                
            } 
        }
    }
}
