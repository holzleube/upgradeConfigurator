using AirbusCatalogue.Common.DataObjects.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirbusCatalogue.Common.DataObjects.Config
{
    public interface IConfigurationFile : IIdentable
    {
        string ConfigurationDate {get; set;}

        string UpgradeCount{get; set;}

        string AircraftCount{get; set;}

        string Filename{get; set;}

        string AircraftProgrammImage{get; set;}

        ConfigurationState State { get; set; }
    }
}
