using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                    new AircraftProgramm("L-Series", "A340/A330", BASE_PATH + "A330_transparent.png"),
                    new AircraftProgramm("P-Series", "A350", BASE_PATH + "A350_transparent.jpg"),
                    new AircraftProgramm("R-Series", "A380", BASE_PATH + "A380_transparent.gif")
                };
            return result;
        }

        public List<AircraftType> GetAircraftTypesByProgramm(string programmId)
        {
            var result = new List<AircraftType>
                {
                    new AircraftType("A318", "A318", BASE_PATH + "A318_transparent.png"),
                    new AircraftType("A319", "A319", BASE_PATH + "A319_transparent_2.png"),
                    new AircraftType("A320", "A320", BASE_PATH + "A320_transparent.png"),
                    new AircraftType("A321", "A321", BASE_PATH + "A321_transparent.png")
                };
            return result;
        }

        public List<AircraftVersion> GetAircraftVersionsByType(string aircraftType)
        {
            

            var list = new List<Aircraft>
                {
                    new Aircraft("N-001", "MSN-001", BASE_PATH + "A318_transparent.png", "001", "AFR01"),
                    new Aircraft("N-002", "MSN-002", BASE_PATH + "A318_transparent.png", "001", "AFR01"),
                    new Aircraft("N-003", "MSN-003", BASE_PATH + "A318_transparent.png", "001", "AFR01"),
                    new Aircraft("N-004", "MSN-004", BASE_PATH + "A318_transparent.png", "001", "AFR01")
                };
            
            var list2 =  new List<Aircraft>
                {
                    new Aircraft("N-001","MSN-004",BASE_PATH + "A318_transparent.png", "001", "AFR02"),
                    new Aircraft("N-001","MSN-005",BASE_PATH + "A318_transparent.png", "001", "AFR02"),
                    new Aircraft("N-001","MSN-006",BASE_PATH + "A318_transparent.png", "001", "AFR05") };
           
           
            var list3 = new List<Aircraft>
                {
                    new Aircraft("N-001","MSN-007",BASE_PATH + "A318_transparent.png", "001", "AFR05"),
                    new Aircraft("N-001","MSN-008",BASE_PATH + "A318_transparent.png", "001", "AFR05"),
                    new Aircraft("N-001","MSN-009",BASE_PATH + "A318_transparent.png", "001", "AFR05"),
                    new Aircraft("N-001","MSN-010",BASE_PATH + "A318_transparent.png", "001", "AFR05"),
                    new Aircraft("N-001","MSN-011",BASE_PATH + "A318_transparent.png", "001", "AFR05"),
                    new Aircraft("N-001","MSN-012",BASE_PATH + "A318_transparent.png", "001", "AFR07") };
            list4 = new List<Aircraft>
                {
                    new Aircraft("N-001","MSN-013",BASE_PATH + "A318_transparent.png", "001", "AFR07"),
                    new Aircraft("N-001","MSN-014",BASE_PATH + "A318_transparent.png", "001", "AFR07") };
            var list5 = new List<Aircraft>
                {
                    new Aircraft("N-001","MSN-015",BASE_PATH + "A318_transparent.png", "001", "AFR09"),
                    new Aircraft("N-001","MSN-016",BASE_PATH + "A318_transparent.png", "001", "AFR09"),
                };
            var aircraftVersion1 = new AircraftVersion("AFR-01", "AFR01") { Aircrafts = list };
            var aircraftVersion2 = new AircraftVersion("AFR-02", "AFR02") { Aircrafts = list2 };
            var aircraftVersion3 = new AircraftVersion("AFR-05", "AFR05") { Aircrafts = list3 };
            var aircraftVersion5 = new AircraftVersion("AFR-07", "AFR07") { Aircrafts = list4 };
            var aircraftVersion6 = new AircraftVersion("AFR-09", "AFR09") { Aircrafts = list5 };
            return  new List<AircraftVersion> {aircraftVersion1, aircraftVersion2, aircraftVersion3, 
                 aircraftVersion5, aircraftVersion6};
        }

        public List<Aircraft> GetSelectedAircrafts()
        {
            return list4;
        }

        public void SelectAircraftProgramm(AircraftProgramm programm)
        {
            var configuration = SimpleIoc.Default.GetInstance<IConfiguration>();
            configuration.Programm = programm;
        }

        public void SelectOrRemoveAircraft(string aircraftId)
        {
            var configuration = SimpleIoc.Default.GetInstance<IConfiguration>();
            if (configuration.AircraftIds.Contains(aircraftId))
            {
                configuration.AircraftIds.Remove(aircraftId);
            }
            else
            {
                configuration.AircraftIds.Add(aircraftId);
            }
        }
    }
}
