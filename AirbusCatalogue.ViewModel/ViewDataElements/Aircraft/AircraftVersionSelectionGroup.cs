using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.Common.DataObjects.Aircrafts;

namespace AirbusCatalogue.ViewModel.ViewDataElements.Aircraft
{
    public class AircraftVersionSelectionGroup : BasicDataItem
    {

        public AircraftVersionSelectionGroup(DataGroup @aircraftGroup, List<IAircraft> aircrafts): base("","","",@aircraftGroup,55,0)
        {
            SetProperties(aircrafts[0]);
            SetAircraftList(aircrafts, @aircraftGroup);
            SetRightColumnSpan(aircrafts.Count);
        }

        private void SetRightColumnSpan(int count)
        {
            var countWithoutFirstPage = count - 3;
            if (countWithoutFirstPage > 0)
            {
                var factor = countWithoutFirstPage / 2;
                ColSpan = factor * 20;
            }
            ColSpan += 40;
        }

        private void SetAircraftList(List<IAircraft> aircrafts, DataGroup @group)
        {
            AircraftList = new ObservableCollection<AircraftSelectionDataItem>();
            if (aircrafts.Count == 1)
            {
                AircraftList.Add(new AircraftSelectionDataItem(aircrafts[0], @group, 30,30));
                return;
            }
            foreach (var aircraft in aircrafts)
            {
                AircraftList.Add(new AircraftSelectionDataItem(aircraft, group));
            }
        }

        private void SetProperties(IAircraft aircraft)
        {
            Version = aircraft.Version;
            Title = aircraft.AircraftType;
        }

        public ObservableCollection<AircraftSelectionDataItem> AircraftList { get; set; }

        public string Version { get; set; }
    }
}
