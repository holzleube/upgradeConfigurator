using System.Collections.Generic;
using AirbusCatalogue.Common.DataObjects.Config;
using AirbusCatalogue.Model.Aircrafts;
using AirbusCatalogue.Model.Templates;

namespace AirbusCatalogue.Model.ConfigurationData
{
    public class Configuration : Identable,IConfiguration
    {
        public Configuration(string uniqueId, List<UpgradeItem> upgrades, List<string> aircrafts, string configurationDate, string state, AircraftProgramm programm): base(uniqueId)
        {
            AircraftIds = aircrafts;
            Upgrades = upgrades;
            ConfigurationDate = configurationDate;
            State = state;
            Programm = programm;
        }

        public string ConfigurationDate { get; set; }

        public string State { get; set; }

        public List<IAircraft> AircraftIds { get; set; }

        public List<IUpgradeItem> Upgrades { get; set; }

        public AircraftProgramm Programm { get; set; }

        public Customer.Customer ConfigurationCustomer { get; set; }
    }
}
