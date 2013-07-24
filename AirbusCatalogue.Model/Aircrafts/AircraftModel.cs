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

namespace AirbusCatalogue.Model.Aircrafts
{
    public class AircraftModel
    {
        private List<Aircraft> list4;
        private const string BASE_PATH = "Assets/aircrafts/";
        public List<AircraftProgramm> GetAllAircraftProgramms()
        {
            var result = new List<AircraftProgramm>
                {
                    new AircraftProgramm("N-Series", "A320-Family", BASE_PATH + "A320_transparent.png"),
                    new AircraftProgramm("L-Series", "A330/A340", BASE_PATH + "A330_transparent.png"),
                    new AircraftProgramm("P-Series", "A350", BASE_PATH + "A350_transparent.jpg"),
                    new AircraftProgramm("R-Series", "A380", BASE_PATH + "A380_transparent.gif")
                };
            return result;
        }

        public List<IAircraftType> GetAircraftTypesByProgramm(string programmId)
        {
            var result = new List<IAircraftType>
                {
                    new AircraftType("A318", "A318", BASE_PATH + "A318_transparent.png"),
                    new AircraftType("A319", "A319", BASE_PATH + "A319_transparent.png"),
                    new AircraftType("A320", "A320", BASE_PATH + "A320_transparent.png"),
                    new AircraftType("A321", "A321", BASE_PATH + "A321_transparent.png")
                };
            return result;
        }

        public List<AircraftVersion> GetAircraftVersionsByProgramm(IAircraftBase aircraftType)
        {
            string image = "Assets/aircrafts/a320_transparent.png";
            if (aircraftType != null)
            {
                 image = aircraftType.ImagePath;
            }

            var list = new List<Aircraft>
                {
                    new Aircraft("N-001", "MSN-001",  image, "001", "AFR01", "A320"),
                    new Aircraft("N-002", "MSN-002",  image, "001", "AFR01", "A320"),
                    new Aircraft("N-003", "MSN-003",  image, "001", "AFR01", "A320"),
                    new Aircraft("N-004", "MSN-004",  image, "001", "AFR01", "A320")
                };
            
            var list2 =  new List<Aircraft>
                {
                    new Aircraft("N-005","MSN-004", image, "001", "AFR02", "A320"),
                    new Aircraft("N-006","MSN-005", image, "001", "AFR02", "A320"),
                    new Aircraft("N-007","MSN-006", image, "001", "AFR02", "A320") };
           
            var list3 = new List<Aircraft>
                {
                    new Aircraft("N-008","MSN-007", image, "001", "AFR05", "A320"),
                    new Aircraft("N-009","MSN-008", image, "001", "AFR05", "A320"),
                    new Aircraft("N-0011","MSN-009", image, "001", "AFR05", "A320"),
                    new Aircraft("N-0012","MSN-010", image, "001", "AFR05", "A320"),
                    new Aircraft("N-0013","MSN-011", image, "001", "AFR05", "A320"),
                    new Aircraft("N-0014","MSN-012", image, "001", "AFR05", "A320") };
            list4 = new List<Aircraft>
                {
                    new Aircraft("N-0015","MSN-013", image, "001", "AFR07", "A319"),
                    new Aircraft("N-0016","MSN-014", image, "001", "AFR07", "A319") };
            var list5 = new List<Aircraft>
                {
                    new Aircraft("N-0017","MSN-015", image, "001", "AFR09", "A319"),
                    new Aircraft("N-0018","MSN-016", image, "001", "AFR09", "A319"),
                };
            var aircraftVersion1 = new AircraftVersion("AFR-01", "AFR01") { Aircrafts = list };
            var aircraftVersion2 = new AircraftVersion("AFR-02", "AFR02") { Aircrafts = list2 };
            var aircraftVersion3 = new AircraftVersion("AFR-05", "AFR05") { Aircrafts = list3 };
            var aircraftVersion5 = new AircraftVersion("AFR-07", "AFR07") { Aircrafts = list4 };
            var aircraftVersion6 = new AircraftVersion("AFR-09", "AFR09") { Aircrafts = list5 };
            return  new List<AircraftVersion> {aircraftVersion1, aircraftVersion2, aircraftVersion3, 
                 aircraftVersion5, aircraftVersion6};
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
