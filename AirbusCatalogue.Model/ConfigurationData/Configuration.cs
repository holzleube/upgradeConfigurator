using System;
using System.Collections.Generic;
using AirbusCatalogue.Common.BasicData;
using AirbusCatalogue.Common.DataObjects.Aircrafts;
using AirbusCatalogue.Common.DataObjects.Config;
using AirbusCatalogue.Common.DataObjects.Customers;
using AirbusCatalogue.Common.DataObjects.Upgrades;
using AirbusCatalogue.Model.Aircrafts;
using AirbusCatalogue.Model.Templates;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace AirbusCatalogue.Model.ConfigurationData
{
    public class Configuration :Identable,IConfiguration
    {
        private ConfigurationState _configurationState;

        public Configuration(string uniqueId, List<IUpgradeItem> upgrades, List<IAircraft> aircrafts, string configurationDate, ConfigurationState state, IAircraftProgramm programm): base(uniqueId)
        {
            SelectedAircrafts = aircrafts;
            Upgrades = upgrades;
            ConfigurationDate = configurationDate;
            State = state;
            Programm = programm;
            ConfigurationGroups = new List<IConfigurationGroup>();
        }

        public string ConfigurationDate { get; set; }

        public ConfigurationState State
        {
            get
            {
                return _configurationState;
            }
            set
            {
                _configurationState = value;
                OnPropertyChanged();
            }
        }

        public List<IAircraft> SelectedAircrafts { get; set; }

        public List<IUpgradeItem> Upgrades { get; set; }

        public IAircraftProgramm Programm { get; set; }

        public ICustomer ConfigurationCustomer { get; set; }

        public List<IConfigurationGroup> ConfigurationGroups { get; set; }

        public bool HasConfigurationChanged { get; set; }
        
    }
}
