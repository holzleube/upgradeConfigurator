using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.Model.Aircrafts;
using AirbusCatalogue.Model.ConfigurationData;

namespace AirbusCatalogue.Model.Config
{
    public class ConfigurationModel
    {
        public Configuration GetCurrentConfiguration()
        {
            var programm = new AircraftProgramm("a320", "A320", "Assets/aircrafts/a320_transparent.png");
            return new Configuration("config001", new List<UpgradeItem>(),new List<Aircraft>(), "today", "in Progress", programm);
        }
    }
}
