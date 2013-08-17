using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using AirbusCatalogue.Common.DataObjects.Config;

namespace AirbusCatalogue.Model.Json
{
    public class JsonHelper
    {
        private DataContractJsonSerializer _serializer;

        public JsonHelper()
        {
            _serializer = new DataContractJsonSerializer(typeof (IConfiguration));
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
    }
}
