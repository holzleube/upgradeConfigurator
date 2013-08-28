using System.Collections.Generic;
using AirbusCatalogue.Model.Aircrafts;
using AirbusCatalogue.Common.DataObjects.Aircrafts;

namespace AirbusCatalogue.ViewModel.ViewDataElements.Aircraft
{
    public class AircraftProgrammGroup : DataGroup
    {
        public AircraftProgrammGroup(IEnumerable<IAircraftProgramm> allAircrafts) : base("aircraftProgrammes", "", "")
        {
            Items = new System.Collections.ObjectModel.ObservableCollection<Common.DataObjects.General.IIdentable>(allAircrafts);
        }
    }
}
