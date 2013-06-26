using AirbusCatalogue.Common.DataObjects.Aircrafts;

namespace AirbusCatalogue.ViewModel.ViewDataElements.Aircraft
{
    public class AircraftDataItem:BasicDataItem
    {
        public AircraftDataItem(Model.Aircrafts.Aircraft aircraft, DataGroup @group) : base(aircraft.UniqueId, aircraft.Name, aircraft.ImagePath,@group, 15, 25)
        {
            Version = aircraft.Version;
            DataItem = aircraft;
        }
        public string Version { get; set; }

        public IAircraft DataItem { get; set; }
    }
}
