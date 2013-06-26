using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.Model.Aircrafts;
using AirbusCatalogue.ViewModel.Templates;
using AirbusCatalogue.ViewModel.ViewDataElements;
using AirbusCatalogue.ViewModel.ViewDataElements.Aircraft;

namespace AirbusCatalogue.ViewModel.ViewModel
{
    public class SelectAircraftVersionViewModel : GridHolderViewModel
    {
        private AircraftModel _model;

        public SelectAircraftVersionViewModel()
        {
            _model = new AircraftModel();
        }

        public override void Initialize(object parameter)
        {
            var aircraftType = parameter as string;
            var aircrafts = _model.GetAircraftVersionsByType(aircraftType);
            DataGroupElements = GetAsViewData(aircrafts);
            
            //DataGroupElements = new ObservableCollection<DataCommon>(aircraftGroup.GroupBy(x => x.Version)
            //                                                      .Select(x => new DataGroup { Title = x.Key, Items = new ObservableCollection<BasicDataItem>(x.ToList()) }));
        }

        private ObservableCollection<DataCommon> GetAsViewData(IEnumerable<AircraftVersion> aircrafts)
        {
            var selectedAircrafts = _model.GetSelectedAircrafts();
            var result = new ObservableCollection<DataCommon>();
            foreach (var aircraftVersion in aircrafts)
            {
                var group = new DataGroup(aircraftVersion.UniqueId, aircraftVersion.Name, aircraftVersion.ImagePath);
                foreach (var aircraft in aircraftVersion.Aircrafts)
                {
                    var newItem = new AircraftDataItem(aircraft, group);
                    group.Items.Add(newItem);
                    //if (selectedAircrafts.Contains(aircraft))
                    //{
                    //    SelectedItems.Add(newItem);
                    //}

                }
                result.Add(group);
            }
            return result;
        }

        private ObservableCollection<AircraftDataItem> _selectedItems = new ObservableCollection<AircraftDataItem>();
        public ObservableCollection<AircraftDataItem> SelectedItems
        {
            get
            {
                return _selectedItems;
            }
            set
            {
                _selectedItems = value;
                OnPropertyChanged();
            }
        }

        public void UpdateSelection(object clickedItem)
        {
            var item = clickedItem as AircraftDataItem;
            if (item != null)
            {
                _model.SelectOrRemoveAircraft(item.UniqueId);
            }
        }
    }
}
