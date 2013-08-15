using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AirbusCatalogue.Common.DataObjects.Aircrafts;
using AirbusCatalogue.Common.DataObjects.General;
using AirbusCatalogue.Model.Aircrafts;
using AirbusCatalogue.ViewModel.Category.Aircraft;
using AirbusCatalogue.ViewModel.Category.Aircraft.Criterias;
using AirbusCatalogue.ViewModel.Category.Aircraft.Interfaces;
using AirbusCatalogue.ViewModel.Command;
using AirbusCatalogue.ViewModel.Filter;
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

        private RelayCommand _checkAircraftSelectionCommand;


        private IAircraftCategory _selectedFilterValue;
        private List<IAircraft> _allAircrafts;

        public SelectAircraftVersionViewModel()
        {
            _model = new AircraftModel();
            _filterList = new ObservableCollection<IAircraftCategory>(new AircraftCategoryFactory().CreateAircraftCategories());
            _selectedFilterValue = _filterList[0];
        }

        public override void Initialize(object parameter)
        {
            var aircraftProgramm = parameter as IAircraftBase ?? _model.GetCurrentAircraftProgramm();
            _allAircrafts = _model.GetAllAircraftsForCurrentSelectedAircraftProgrammAndCustomer();
            BuildAndSetAircraftsOnView(_allAircrafts, new AircraftVersionCategoryCriteria());
        }

        

        private void BuildAndSetAircraftsOnView(List<IAircraft> aircrafts, ICategoryCriteria<IAircraft> categoryCriteria)
        {
            SelectedItems = new ObservableCollection<IAircraft>(_model.GetSelectedAircrafts());

            var groupedAircrafts =
                from w in aircrafts
                orderby categoryCriteria.GetFilterValue(w)
                group w by categoryCriteria.GetFilterValue(w)
                into g
                select new {Category = g.Key, Products = g};
            var result = new ObservableCollection<IIdentable>();
            foreach (var g in groupedAircrafts)
            {
                var group = new DataGroup(g.Category, g.Category, g.Products.ToList()[0].ImagePath);
                group.Items = new ObservableCollection<IIdentable>(g.Products.ToList());
                result.Add(group);
            }

            DataGroupElements = result;
        }

        private ObservableCollection<IAircraft> _selectedItems = new ObservableCollection<IAircraft>();
        public ObservableCollection<IAircraft> SelectedItems
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

        private ObservableCollection<IAircraftCategory> _filterList = new ObservableCollection<IAircraftCategory>();
        public ObservableCollection<IAircraftCategory> FilterList
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
            var aircraft = clickedItem as IAircraft;
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

        public IAircraftCategory SelectedFilterValue
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
            BuildAndSetAircraftsOnView(_allAircrafts, SelectedFilterValue.CategoryCriteria);
            //if (SelectedFilterValue.Equals(AllItems))
            //{
            //    BuildAndSetAircraftsOnView(_allAircrafts, new AircraftVersionCategoryCriteria());
            //    return;
            //}
            //var resultList = new List<AircraftVersion>();
            //foreach (var aircraftVersion in _allAircrafts)
            //{
            //    var filteredList = aircraftVersion.Aircrafts.Select(x => x).
            //        Where(x => x.AircraftType.Contains(SelectedFilterValue)).ToList();
            //    if (filteredList.Count == 0)
            //    {
            //        continue;
            //    }
            //    var newAircraftVersion = new AircraftVersion(aircraftVersion.UniqueId, aircraftVersion.Name)
            //    {
            //        Aircrafts = filteredList
            //    };
            //    resultList.Add(newAircraftVersion);
                
            //}
            //BuildAndSetAircraftsOnView(resultList, new AircraftVersionCategoryCriteria());
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
            _model.SetAircraftsInConfiguration(SelectedItems.ToList());
            var classToNavigate = SimpleIoc.Default.GetInstance<ISummary>();
            var navigationService = SimpleIoc.Default.GetInstance<INavigationService>();
            navigationService.Navigate(classToNavigate.GetType());
        }
    }
}
