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
    public class AircraftModel
    {
        private List<Aircraft> list4;
        private const string BASE_PATH = "Assets/slider/";
        private const string A320Image = "Assets/allTypes/head_a320.png";
        private const string A321Image = "Assets/allTypes/head_a321.png";
        private const string A319Image = "Assets/allTypes/head_a319.png";
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
            return GetAirfranceAircrafts();
        }

        public List<IAircraft> GetAllAircraftsForCurrentSelectedAircraftProgrammAndCustomer()
        {
            return SimpleIoc.Default.GetInstance<IAircraftRepository>().GetAllAircrafts();
        } 

        private List<AircraftVersion> GetAirfranceAircrafts()
        {
            var list = new List<Aircraft>
                {
                    new Aircraft("N-0002", "N-0002",  A320Image, "001", "AFR01", "A320"),
                    new Aircraft("N-0005", "N-0005",  A320Image, "001", "AFR01", "A320"),
                    new Aircraft("N-0007", "N-0007",  A320Image, "001", "AFR01", "A320"),
                    new Aircraft("N-0009", "N-0009",  A320Image, "001", "AFR01", "A320"),
                    new Aircraft("N-0014", "N-0014",  A320Image, "001", "AFR01", "A320"),
                    new Aircraft("N-0019", "N-0019",  A320Image, "001", "AFR01", "A320"),
                    new Aircraft("N-0020", "N-0020",  A320Image, "001", "AFR01", "A320"),
                    new Aircraft("N-0021", "N-0021",  A320Image, "001", "AFR01", "A320"),
                    new Aircraft("N-0061", "N-0061",  A320Image, "001", "AFR01", "A320"),
                    new Aircraft("N-0062", "N-0062",  A320Image, "001", "AFR01", "A320"),
                    new Aircraft("N-0063", "N-0063",  A320Image, "001", "AFR01", "A320")
                };

            var list2 = new List<Aircraft>
                {
                    new Aircraft("N-0077","MSN-004", A321Image, "001", "AFR02", "A321"),
                    new Aircraft("N-0796","MSN-005", A321Image, "001", "AFR02", "A321"),
                    new Aircraft("N-1133","MSN-005", A321Image, "001", "AFR02", "A321"),
                    new Aircraft("N-1299","MSN-005", A321Image, "001", "AFR02", "A321"),
                    new Aircraft("N-1476","MSN-006", A321Image, "001", "AFR02", "A321") };

            var list3 = new List<Aircraft>
                {
                    new Aircraft("N-0938","MSN-007", A319Image, "001", "AFR03", "A319"),
                    new Aircraft("N-0985","MSN-008", A319Image, "001", "AFR03", "A319"),
                    new Aircraft("N-0998","MSN-009", A319Image, "001", "AFR03", "A319"),
                    new Aircraft("N-1000","MSN-010", A319Image, "001", "AFR03", "A319"),
                    new Aircraft("N-1020","MSN-011", A319Image, "001", "AFR03", "A319"),
                    new Aircraft("N-1025","MSN-012", A319Image, "001", "AFR03", "A319") };
            var list6 = new List<Aircraft>
                {
                    new Aircraft("N-1873","MSN-013", A320Image, "001", "AFR06", "A320"),
                    new Aircraft("N-1873","MSN-013", A320Image, "001", "AFR06", "A320"),
                    new Aircraft("N-1894","MSN-013", A320Image, "001", "AFR06", "A320"),
                    new Aircraft("N-2140","MSN-014", A320Image, "001", "AFR06", "A320") };


            var list10 = new List<Aircraft>
                {
                    new Aircraft("N-1924","MSN-015", A320Image, "001", "AFR10", "A320"),
                    new Aircraft("N-1949","MSN-016", A320Image, "001", "AFR10", "A320"),
                };
            var list11 = new List<Aircraft>
                {
                    new Aircraft("N-2213","MSN-013", A319Image, "001", "AFR11", "A319"),
                    new Aircraft("N-2228","MSN-013", A319Image, "001", "AFR11", "A319"),
                    new Aircraft("N-2279","MSN-013", A319Image, "001", "AFR11", "A319"),
                    new Aircraft("N-2456","MSN-013", A319Image, "001", "AFR11", "A319"),
                    new Aircraft("N-2716","MSN-013", A319Image, "001", "AFR11", "A319"),
                    new Aircraft("N-3065","MSN-014", A319Image, "001", "AFR11", "A319") };

            var aircraftVersion1 = new AircraftVersion("AFR-01", "AFR01") { Aircrafts = list };
            var aircraftVersion2 = new AircraftVersion("AFR-02", "AFR02") { Aircrafts = list2 };
            var aircraftVersion3 = new AircraftVersion("AFR-03", "AFR03") { Aircrafts = list3 };
            var aircraftVersion6 = new AircraftVersion("AFR-06", "AFR06") { Aircrafts = list6 };
            var aircraftVersion10 = new AircraftVersion("AFR-10", "AFR10") { Aircrafts = list10 };
            var aircraftVersion11 = new AircraftVersion("AFR-11", "AFR11") { Aircrafts = list11 };
            return new List<AircraftVersion> {aircraftVersion1, aircraftVersion2, aircraftVersion3, 
                 aircraftVersion6, aircraftVersion10, aircraftVersion11};
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
