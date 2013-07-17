using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AirbusCatalogue.Common.DataObjects.Aircrafts;
using AirbusCatalogue.Common.DataObjects.General;
using AirbusCatalogue.Model.Aircrafts;
using AirbusCatalogue.ViewModel.Command;
using AirbusCatalogue.ViewModel.Navigation;
using AirbusCatalogue.ViewModel.Templates;
using AirbusCatalogue.ViewModel.ViewDataElements;
using AirbusCatalogue.ViewModel.ViewDataElements.Aircraft;
using AirbusCatalogue.ViewModel.ViewInterfaces;
using GalaSoft.MvvmLight.Ioc;

namespace AirbusCatalogue.ViewModel.ViewModel.Aircraft
{
    public class SelectAircraftVersionViewModel : GridHolderViewModel
    {
        private readonly AircraftModel _model;
        private const string AllItems = "all types";

        private RelayCommand _checkAircraftSelectionCommand;
       

        private string _selectedFilterValue;
        private List<AircraftVersion> _allAircrafts;

        public SelectAircraftVersionViewModel()
        {
            _model = new AircraftModel();
        }

        public override void Initialize(object parameter)
        {
            var aircraftProgramm = parameter as IAircraftBase ?? _model.GetCurrentAircraftProgramm();
            _allAircrafts = _model.GetAircraftVersionsByProgramm(aircraftProgramm);
            AddAircraftTypesToFilter(aircraftProgramm);
            BuildAndSetAircraftsOnView(_allAircrafts);
        }

        private void AddAircraftTypesToFilter(IAircraftBase aircraftProgramm)
        {
            if (aircraftProgramm == null)
            {
                return;
            }
            var aircraftTypes = _model.GetAircraftTypesByProgramm(aircraftProgramm.UniqueId);
            FilterList.Add(AllItems);
            foreach (var aircraftType in aircraftTypes)
            {
                FilterList.Add(aircraftType.Name);
            }
            SelectedFilterValue = AllItems;
        }

        private void BuildAndSetAircraftsOnView(IEnumerable<AircraftVersion> aircrafts)
        {
            SelectedItems = new ObservableCollection<AircraftDataItem>();
            var selectedAircrafts = _model.GetSelectedAircrafts();
            var result = new ObservableCollection<DataCommon>();
            foreach (var aircraftVersion in aircrafts)
            {
                var group = new DataGroup(aircraftVersion.UniqueId, aircraftVersion.Name, aircraftVersion.ImagePath);
                foreach (var aircraft in aircraftVersion.Aircrafts)
                {
                    var newItem = new AircraftDataItem(aircraft, group);
                    group.Items.Add(newItem);
                    if (selectedAircrafts.Contains(aircraft))
                    {
                        SelectedItems.Add(newItem);
                    }
                }
                result.Add(group);
            }
            DataGroupElements = result;
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

        private ObservableCollection<string> _filterList = new ObservableCollection<string>();
        public ObservableCollection<string> FilterList
        {
            get
            {
                return _filterList;
            }
            set
            {
                _filterList = value;
                OnPropertyChanged();
            }
        }

        public void UpdateSelection(object clickedItem)
        {
            var aircraft = clickedItem as AircraftDataItem;
            if (aircraft != null)
            {
                if (SelectedItems.Contains(aircraft))
                {
                    SelectedItems.Remove(aircraft);
                }
                else
                {
                    SelectedItems.Add(aircraft);
                }
            }
        }

        public string SelectedFilterValue
        {
            get
            {
                return _selectedFilterValue;
            }
            set
            {
                _selectedFilterValue = value;
                FilterAircraftList();
                OnPropertyChanged();
            }
        }

        private void FilterAircraftList()
        {
            if (SelectedFilterValue.Equals(AllItems))
            {
                BuildAndSetAircraftsOnView(_allAircrafts);
                return;
            }
            var resultList = new List<AircraftVersion>();
            foreach (var aircraftVersion in _allAircrafts)
            {
                var filteredList = aircraftVersion.Aircrafts.Select(x => x).
                    Where(x => x.AircraftType.Contains(SelectedFilterValue)).ToList();
                if (filteredList.Count == 0)
                {
                    continue;
                }
                var newAircraftVersion = new AircraftVersion(aircraftVersion.UniqueId, aircraftVersion.Name)
                {
                    Aircrafts = filteredList
                };
                resultList.Add(newAircraftVersion);
                
            }
            BuildAndSetAircraftsOnView(resultList);
        }

       
        
        public RelayCommand CheckAircraftSelectionCommand
        {
            get {
                return _checkAircraftSelectionCommand ??
                       (_checkAircraftSelectionCommand = new RelayCommand(ValidateAircraftsAndSelectThem));
            }
        }

        private void ValidateAircraftsAndSelectThem()
        {
            var aircrafts = SelectedItems.Select(x => x.DataItem).ToList();
            _model.SetAircraftsInConfiguration(aircrafts);
            var classToNavigate = SimpleIoc.Default.GetInstance<ISummary>();
            var navigationService = SimpleIoc.Default.GetInstance<INavigationService>();
            navigationService.Navigate(classToNavigate.GetType());
        }
    }
}
