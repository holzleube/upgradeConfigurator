using System;
using System.Collections.Generic;
using AirbusCatalogue.Common.DataObjects.Aircrafts;
using AirbusCatalogue.Common.DataObjects.Config;
using AirbusCatalogue.Common.DataObjects.Customers;
using AirbusCatalogue.Model.Aircrafts;
using AirbusCatalogue.Model.Templates;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace AirbusCatalogue.Model.ConfigurationData
{
    public class Configuration : Identable,IConfiguration
    {
        

        public Configuration(string uniqueId, List<IUpgradeItem> upgrades, List<IAircraft> aircrafts, string configurationDate, string state, IAircraftProgramm programm): base(uniqueId)
        {
            SelectedAircrafts = aircrafts;
            Upgrades = upgrades;
            ConfigurationDate = configurationDate;
            State = state;
            Programm = programm;
        }

        public string ConfigurationDate { get; set; }

        public string State { get; set; }

        public List<IAircraft> SelectedAircrafts { get; set; }

        public List<IUpgradeItem> Upgrades { get; set; }

        public IAircraftProgramm Programm { get; set; }

        public ICustomer ConfigurationCustomer { get; set; }

        
    }
}
