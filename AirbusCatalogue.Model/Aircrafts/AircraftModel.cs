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
using AirbusCatalogue.Model.ConfigurationData;

namespace AirbusCatalogue.Model.Aircrafts
{
    /// <summary>
    /// This model provides all data for aircrafts. It holds single aircrafts
    /// and also the aircraft programms. You can also set the aircraft in the current
    /// configuration.
    /// </summary>
    public class AircraftModel
    {
        

        public List<IAircraftProgramm> GetAllAircraftProgramms()
        {
            return SimpleIoc.Default.GetInstance<IAircraftRepository>().GetAllAircraftProgramms();
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

        public void SelectAircraftProgramm(IAircraftProgramm programm)
        {
            var configuration = SimpleIoc.Default.GetInstance<IConfiguration>();
            configuration.Programm = programm;
            configuration.SelectedAircrafts = new List<IAircraft>();
            configuration.Upgrades = new List<IUpgradeItem>();
            configuration.ConfigurationGroups = new List<IConfigurationGroup>();
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
