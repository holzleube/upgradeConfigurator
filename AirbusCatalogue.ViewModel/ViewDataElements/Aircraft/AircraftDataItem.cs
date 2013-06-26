namespace AirbusCatalogue.ViewModel.ViewDataElements.Aircraft
{
    public class AircraftDataItem:BasicDataItem
    {
        public AircraftDataItem(Model.Aircrafts.Aircraft aircraft, DataGroup @group) : base(aircraft.UniqueId, aircraft.Name, aircraft.ImagePath,@group, 15, 25)
        {
            Version = aircraft.Version;
        }
        public string Version { get; set; }

    }
}
