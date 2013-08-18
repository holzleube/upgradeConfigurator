using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
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
    [DataContract]
    public class Configuration : Identable, IConfiguration
    {
        private ConfigurationState _configurationState;

        public Configuration(string uniqueId, List<IUpgradeItem> upgrades, List<IAircraft> aircrafts, string configurationDate, ConfigurationState state, IAircraftProgramm programm, ICustomer customer): base(uniqueId)
        {
            SelectedAircrafts = aircrafts;
            Upgrades = upgrades;
            ConfigurationDate = configurationDate;
            State = state;
            Programm = programm;
            ConfigurationGroups = new List<IConfigurationGroup>();
            Customer = customer;
        }

        [DataMember]
        public string ConfigurationDate { get; set; }

        [DataMember]
        public ConfigurationState State
        {
            get
            {
                return _configurationState;
            }
            set
            {
                _configurationState = value;
               
            }
        }
        [DataMember]
        public List<IAircraft> SelectedAircrafts { get; set; }

        [DataMember]
        public List<IUpgradeItem> Upgrades { get; set; }

        [DataMember]
        public IAircraftProgramm Programm { get; set; }

        [DataMember]
        public List<IConfigurationGroup> ConfigurationGroups { get; set; }

        [DataMember]
        public bool HasConfigurationChanged { get; set; }

        [DataMember]
        public ICustomer Customer { get; set; }
        
    }
}
