using System.Collections.Generic;
using AirbusCatalogue.Common.DataObjects.Aircrafts;
using AirbusCatalogue.Common.DataObjects.Customers;
using AirbusCatalogue.Common.DataObjects.General;

namespace AirbusCatalogue.Common.DataObjects.Config
{
    public interface IConfiguration: IIdentable
    {
        string ConfigurationDate { get; set; }

        string State { get; set; }

        List<IAircraft> SelectedAircrafts { get; set; }

        List<IUpgradeItem> Upgrades { get; set; }

        IAircraftProgramm Programm { get; set; }

        ICustomer ConfigurationCustomer { get; set; }
    }
}
