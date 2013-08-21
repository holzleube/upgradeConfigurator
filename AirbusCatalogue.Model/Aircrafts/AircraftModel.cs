using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.Common.DataObjects.Aircrafts;
using AirbusCatalogue.Common.DataObjects.Config;
using AirbusCatalogue.Common.DataObjects.Upgrades;
using AirbusCatalogue.Model.Templates;
using GalaSoft.MvvmLight.Ioc;
using AirbusCatalogue.Model.Repository;

namespace AirbusCatalogue.Model.Aircrafts
{
    /// <summary>
    /// This model provides all data for aircrafts. It holds single aircrafts
    /// and also the aircraft programms. You can also set the aircraft in the current
    /// configuration.
    /// </summary>
    public class AircraftModel
    {
        private const string BASE_PATH = "/Assets/slider/";

        public List<AircraftProgramm> GetAllAircraftProgramms()
        {
            var result = new List<AircraftProgramm>
                {
                    new AircraftProgramm("N-Series", "A320-Family", BASE_PATH + "slider_a320.png"),
                    new AircraftProgramm("L-Series", "A330/A340", BASE_PATH + "slider_a330.png"),
                    new AircraftProgramm("P-Series", "A350", BASE_PATH + "slider_a350.png"),
                    new AircraftProgramm("R-Series", "A380", BASE_PATH + "slider_a380.png")
                };
            return result;
        }

        public List<IAircraft> GetAllAircraftsForCurrentSelectedAircraftProgrammAndCustomer()
        {
            return SimpleIoc.Default.GetInstance<IAircraftRepository>().GetAllAircrafts();
        } 

        public List<IAircraft> GetSelectedAircrafts()
        {
            var configuration = GetCurrentConfiguration();
            return configuration.SelectedAircrafts;
        }

        private static IConfiguration GetCurrentConfiguration()
        {
            return SimpleIoc.Default.GetInstance<IConfiguration>();
        }

        public void SelectAircraftProgramm(AircraftProgramm programm)
        {
            var configuration = SimpleIoc.Default.GetInstance<IConfiguration>();
            configuration.Programm = programm;
            configuration.SelectedAircrafts = new List<IAircraft>();
            configuration.Upgrades = new List<IUpgradeItem>();
        }

        public void SetAircraftsInConfiguration(List<IAircraft> aircrafts)
        {
            var configuration = GetCurrentConfiguration();
            configuration.SelectedAircrafts = aircrafts;
            configuration.HasConfigurationChanged = true;
        }

        public IAircraftBase GetCurrentAircraftProgramm()
        {
            return GetCurrentConfiguration().Programm;
        }
    }
}
