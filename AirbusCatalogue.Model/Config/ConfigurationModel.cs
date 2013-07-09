using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using AirbusCatalogue.Common.DataObjects.Config;
using AirbusCatalogue.Model.de.cas.web.consultation.webservices.configuration;
using GalaSoft.MvvmLight.Ioc;
using AirbusConfigurationWebServiceClient = AirbusCatalogue.Model.DebugReference.AirbusConfigurationWebServiceClient;

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
            
            var basicHttpBinding = new BasicHttpBinding(BasicHttpSecurityMode.TransportWithMessageCredential);
            //basicHttpBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Certificate;
            string URL = "https://localhost:9090/H970live/services/Configuration";
            EndpointAddress endpoint = new EndpointAddress(URL);
            var locator =
                new AirbusConfigurationWebServiceClient(basicHttpBinding, endpoint);

            locator.ClientCredentials.UserName.UserName = "dane.leube@cas.de";
            locator.ClientCredentials.UserName.Password = "";
           
           
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
