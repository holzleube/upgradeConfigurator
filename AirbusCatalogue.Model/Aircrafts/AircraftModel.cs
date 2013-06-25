using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirbusCatalogue.Model.Aircrafts
{
    public class AircraftModel
    {
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
                    new AircraftType("N-Series", "A319", BASE_PATH + "A320_transparent.png"),
                    new AircraftType("L-Series", "A320", BASE_PATH + "A330_transparent.png"),
                    new AircraftType("P-Series", "A321", BASE_PATH + "A350_transparent.jpg"),
                    new AircraftType("R-Series", "A318", BASE_PATH + "A380_transparent.gif")
                };
            return result;
        } 
    }
}
