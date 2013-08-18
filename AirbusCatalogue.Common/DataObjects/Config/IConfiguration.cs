using System.Collections.Generic;
using System.Runtime.Serialization;
using AirbusCatalogue.Common.DataObjects.Aircrafts;
using AirbusCatalogue.Common.DataObjects.Customers;
using AirbusCatalogue.Common.DataObjects.General;
using AirbusCatalogue.Common.DataObjects.Upgrades;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace AirbusCatalogue.Common.DataObjects.Config
{
    public interface IConfiguration: IIdentable
    {
        string ConfigurationDate { get; set; }

        ConfigurationState State { get; set; }

        List<IAircraft> SelectedAircrafts { get; set; }

        List<IUpgradeItem> Upgrades { get; set; }

        IAircraftProgramm Programm { get; set; }

        ICustomer Customer { get; set; }

        List<IConfigurationGroup> ConfigurationGroups { get; set; }

        bool HasConfigurationChanged { get; set; }
    }

    
}
