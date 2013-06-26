using System;
using AirbusCatalogue.Common.DataObjects.Aircrafts;
using AirbusCatalogue.Model.Templates;

namespace AirbusCatalogue.Model.Aircrafts
{
    public class AircraftProgramm : AAircraftBase, IAircraftProgramm
    {
        public AircraftProgramm(string uniqueId, string name, string imagePath) :base(uniqueId, name, imagePath)
        {
           
        }
    }
}
