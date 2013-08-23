using AirbusCatalogue.Common.DataObjects.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirbusCatalogue.Model.ConfigurationData
{
    public class ConfigurationFile: IConfigurationFile
    {
        public ConfigurationFile(string id, string configurationDate, string upgradeCount, string aircraftCount, string filename, string programmImage,
            ConfigurationState state)
        {
            UniqueId = id;
            ConfigurationDate = configurationDate;
            UpgradeCount = upgradeCount;
            AircraftCount = aircraftCount;
            Filename = filename;
            AircraftProgrammImage = programmImage;
            State = state;
        }

        public string ConfigurationDate { get; set; }

        public string UpgradeCount { get; set; }

        public string AircraftCount { get; set; }

        public string Filename { get; set; }

        public string AircraftProgrammImage { get; set; }

        public ConfigurationState State { get; set; }

        public string UniqueId {get; set;}
    }
}
