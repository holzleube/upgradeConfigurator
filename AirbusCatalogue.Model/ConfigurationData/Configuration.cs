using System.Collections.Generic;
using AirbusCatalogue.Model.Aircrafts;
using AirbusCatalogue.Model.Templates;

namespace AirbusCatalogue.Model.ConfigurationData
{
    public class Configuration : Identable
    {
        public Configuration(string uniqueId, List<UpgradeItem> upgrades, List<Aircraft> aircrafts, string configurationDate, string state, AircraftProgramm programm): base(uniqueId)
        {
            Aircrafts = aircrafts;
            Upgrades = upgrades;
            ConfigurationDate = configurationDate;
            State = state;
            Programm = programm;
        }

        public string ConfigurationDate { get; set; }

        public string State { get; set; }

        public List<Aircraft> Aircrafts { get; set; }

        public List<UpgradeItem> Upgrades { get; set; }

        public AircraftProgramm Programm { get; set; }


    }
}
