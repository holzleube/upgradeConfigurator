using System;
using AirbusCatalogue.Common.DataObjects.Config;
using AirbusCatalogue.Model.de.cas.web.consultation.webservices.configuration;
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
            var locator =
                new AirbusConfigurationWebServiceClient();

            try
            {
                var result = await locator.checkAircraftValidityAsync(new string[] {"N-0001", "N-0002"},
                                                                      "/SA/02/12/Net flight path");
            }
            catch (Exception e)
            {
                
            } 
        }
    }
}
