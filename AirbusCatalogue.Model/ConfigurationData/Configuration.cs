using System.Collections.Generic;
using AirbusCatalogue.Model.Aircrafts;
using AirbusCatalogue.Model.Templates;

namespace AirbusCatalogue.Model.ConfigurationData
{
    public class Configuration : Identable
    {
        public Configuration(string uniqueId, List<UpgradeItem> upgrades, List<Aircraft> aircrafts, string aircraftImagePath, string configurationDate, string state)
        {
            UniqueId = uniqueId;
            Aircrafts = aircrafts;
            Upgrades = upgrades;
            AircraftImagePath = aircraftImagePath;
            ConfigurationDate = configurationDate;
            State = state;
        }

        public string AircraftImagePath { get; set; }

        public string ConfigurationDate { get; set; }

        public string State { get; set; }

        public List<Aircraft> Aircrafts { get; set; }

        public List<UpgradeItem> Upgrades { get; set; }



    }
}
