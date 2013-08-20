using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using AirbusCatalogue.Common.DataObjects.Config;
using AirbusCatalogue.Common.DataObjects.Customers;
using AirbusCatalogue.Model.ConfigurationData;
using Newtonsoft.Json;
using AirbusCatalogue.Model.File;
using Windows.Storage.Streams;


namespace AirbusCatalogue.Model.Json
{
    public class JsonHelper
    {
        private DataContractJsonSerializer _serializer;

        public JsonHelper()
        {
            _serializer = new DataContractJsonSerializer(typeof(Configuration));
        }
        public string GetJsonFromConfiguration(IConfiguration configuration)
        {
            var stream = new MemoryStream();
            _serializer.WriteObject(stream, configuration);
            stream.Position = 0;
            var sr = new StreamReader(stream);
            return sr.ReadToEnd();
        }

        public IConfiguration GetConfigurationFromJson(string jsonText)
        {
            var bytes = Encoding.Unicode.GetBytes(jsonText);
            using (var stream = new MemoryStream(bytes))
            {
                return (IConfiguration) _serializer.ReadObject(stream);
            }
        }

        public string GetJsonFromDummy(DummyObject configuration)
        {
            var serializer = new DataContractJsonSerializer(typeof(DummyObject));
            var result = JsonConvert.SerializeObject(configuration, Formatting.Indented);
            var stream = new MemoryStream();
            serializer.WriteObject(stream, configuration);
            stream.Position = 0;
            var sr = new StreamReader(stream);
            return sr.ReadToEnd();
        }
    }
}
