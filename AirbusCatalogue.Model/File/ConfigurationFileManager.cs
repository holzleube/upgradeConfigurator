using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.Common.DataObjects.Config;
using AirbusCatalogue.Model.Json;
using Windows.Storage;
using AirbusCatalogue.Common.DataObjects.Customers;
using AirbusCatalogue.Model.ConfigurationData;
using Windows.Storage.Streams;

namespace AirbusCatalogue.Model.File
{
    public class ConfigurationFileManager
    {
        private StorageFolder _dataFolder;
        private JsonHelper _jsonHelper = new JsonHelper();
        private string _fileExtension = ".json";

        public ConfigurationFileManager()
        {
            _dataFolder = ApplicationData.Current.LocalFolder;
        }
        public async Task<IConfiguration> GetConfigurationByDate(string id)
        {
            var file = await _dataFolder.GetFileAsync(id + _fileExtension);
           
            var buffer = await Windows.Storage.FileIO.ReadBufferAsync(file);
            DataReader dataReader = Windows.Storage.Streams.DataReader.FromBuffer(buffer);
            string jsonText = dataReader.ReadString(buffer.Length);
            return _jsonHelper.GetConfigurationFromJson(jsonText);
        }

        public async void WriteConfigurationToFile(Configuration configuration)
        {
            var jsonText = _jsonHelper.GetJsonFromConfiguration(configuration);
            var file = await _dataFolder.CreateFileAsync(configuration.ConfigurationDate + _fileExtension);
            await FileIO.WriteTextAsync(file, jsonText);
        }
    }

}
