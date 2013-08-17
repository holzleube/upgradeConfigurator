using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.Common.DataObjects.Config;
using AirbusCatalogue.Model.Json;
using Windows.Storage;

namespace AirbusCatalogue.Model.File
{
    public class ConfigurationFileManager
    {
        private StorageFolder _dataFolder;
        private JsonHelper _jsonHelper = new JsonHelper();

        public ConfigurationFileManager()
        {
            _dataFolder = ApplicationData.Current.LocalFolder;
        }
        public async Task<IConfiguration> GetConfigurationByDate(string id)
        {
            var file = await _dataFolder.GetFileAsync(id);
            var jsonText = await FileIO.ReadTextAsync(file);
            return _jsonHelper.GetConfigurationFromJson(jsonText);
        }

        public async void WriteConfigurationToFile(IConfiguration configuration)
        {
            var jsonText = _jsonHelper.GetJsonFromConfiguration(configuration);
            var file = await _dataFolder.CreateFileAsync(configuration.ConfigurationDate);
            await FileIO.WriteTextAsync(file, jsonText);
        }
    }

}
