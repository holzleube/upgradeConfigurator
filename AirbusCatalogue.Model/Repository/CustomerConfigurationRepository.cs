using AirbusCatalogue.Common.DataObjects.Config;
using AirbusCatalogue.Model.ConfigurationData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirbusCatalogue.Model.Repository
{
    /// <summary>
    /// This repository holds the configurationfiles for a single customer. 
    /// The file is on filesystem with json serialization. The configurationfile is
    /// for showing the information in startpage. Curently it used dummy data for the first
    /// 6 entries.
    /// </summary>
    public class CustomerConfigurationRepository : ICustomerConfigurationRespository
    {
        private Dictionary<string, List<IConfigurationFile>> _customerMap;

        private const string BASE_PATH_AIRCRAFT = "Assets/slider/";

        public CustomerConfigurationRepository()
        {
            _customerMap = new Dictionary<string, List<IConfigurationFile>>();
        }
        public List<IConfigurationFile> GetCurentConfigurationsByCustomerId(string customerId)
        {
            var configurations = GetConfigurationFilesForCustomer(customerId);
            
            var defaultConfigurations = GetDefaultConfigurationFiles();
            
            if (configurations.Count > 0)
            {
                defaultConfigurations.RemoveRange(defaultConfigurations.Count - 1 - configurations.Count, configurations.Count);
                foreach (var configuration in configurations)
                {
                    defaultConfigurations.Insert(0, configuration);
                }
            }
            return defaultConfigurations;
        }

        private List<IConfigurationFile> GetConfigurationFilesForCustomer(string customerId)
        {
            var configurations = new List<IConfigurationFile>();
            try
            {
                return _customerMap[customerId];
            }
            catch (KeyNotFoundException e)
            {
                _customerMap.Add(customerId, configurations);
                return _customerMap[customerId];
            }
        }

        public void SaveConfigurationForCustomer(IConfigurationFile configuration, string customerId)
        {
            var configurations = GetConfigurationFilesForCustomer(customerId);
            configurations.Add(configuration);
        }

        private List<IConfigurationFile> GetDefaultConfigurationFiles()
        {
            var programms = new List<string>()
                {
                    BASE_PATH_AIRCRAFT + "slider_a320.png", 
                    BASE_PATH_AIRCRAFT + "slider_a330.png",
                    BASE_PATH_AIRCRAFT + "slider_a350.png",
                    BASE_PATH_AIRCRAFT + "slider_a380.png"
                };
            return new List<IConfigurationFile>
                {
                    new ConfigurationFile("configuration1", "16.03.2013", "2", "9", "16.03.2013", programms[2],ConfigurationState.IN_PROGRESS),
                    new ConfigurationFile("configuration2" ,"16.01.2013","2", "2","16.01.2013",programms[0],ConfigurationState.IN_PROGRESS),
                    new ConfigurationFile("configuration3"  ,"13.03.2012","3", "4" ,"13.03.2012",programms[0],ConfigurationState.DELIVERED),
                    new ConfigurationFile("configuration4",  "11.09.2010","1", "s6","11.09.2010",programms[0],ConfigurationState.DELIVERED),
                    new ConfigurationFile("configuration5", "08.03.2010","4", "3", "08.03.2010",programms[3],ConfigurationState.DELIVERED),
                    new ConfigurationFile("configuration6",  "01.08.2009","8", "8", "01.08.2009",programms[3],ConfigurationState.DELIVERED)
                };
        }
    }
}
