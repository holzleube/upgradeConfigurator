using System.Collections.Generic;
using AirbusCatalogue.Model.Aircrafts;

namespace AirbusCatalogue.ViewModel.ViewDataElements.Aircraft
{
    public class AircraftProgrammGroup : DataGroup
    {
        public AircraftProgrammGroup(IEnumerable<AircraftProgramm> allAircrafts) : base("aircraftProgrammes", "", "")
        {
            Items = new System.Collections.ObjectModel.ObservableCollection<Common.DataObjects.General.IIdentable>(allAircrafts);
        }
    }
}
