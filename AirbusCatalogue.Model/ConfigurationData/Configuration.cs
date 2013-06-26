using System.Collections.Generic;
using AirbusCatalogue.Common.DataObjects.Aircrafts;
using AirbusCatalogue.Common.DataObjects.Config;
using AirbusCatalogue.Common.DataObjects.Customers;
using AirbusCatalogue.Model.Aircrafts;
using AirbusCatalogue.Model.Templates;

namespace AirbusCatalogue.Model.ConfigurationData
{
    public class Configuration : Identable,IConfiguration
    {
        public Configuration(string uniqueId, List<IUpgradeItem> upgrades, List<IAircraft> aircrafts, string configurationDate, string state, IAircraftProgramm programm): base(uniqueId)
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

        public IAircraftProgramm Programm { get; set; }

        public ICustomer ConfigurationCustomer { get; set; }
    }
}
