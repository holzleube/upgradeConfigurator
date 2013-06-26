using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.Common.DataObjects.Aircrafts;
using AirbusCatalogue.Common.DataObjects.Config;
using AirbusCatalogue.Model.Aircrafts;
using AirbusCatalogue.Model.ConfigurationData;
using AirbusCatalogue.Model.Templates;
using GalaSoft.MvvmLight.Ioc;

namespace AirbusCatalogue.Model.Config
{
    public class ConfigurationModel
    {
        public Configuration GetCurrentConfiguration()
        {
            var currentConfiguration = SimpleIoc.Default.GetInstance<IConfiguration>();
            //var programm = new AircraftProgramm("a320", "A320", "Assets/aircrafts/a320_transparent.png");
            return new Configuration("config001", new List<IUpgradeItem>(),new List<IAircraft>(), "today", "in Progress", currentConfiguration.Programm);
        }
    }
}
