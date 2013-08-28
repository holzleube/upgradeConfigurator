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
    /// <summary>
    /// This viewModel gets the data from aircraft model and holds it for the view.
    /// The logic for grouping the items for using the semantic zoom is done here. 
    /// Also it holds the selected aircrafts and the categories for the listbox.
    /// </summary>
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
            SelectedItems = new ObservableCollection<IAircraft>(_model.GetSelectedAircrafts());
        }

        public override void Initialize(object parameter)
        {
            var aircraftProgramm = parameter as IAircraftBase ?? _model.GetCurrentAircraftProgramm();
            _allAircrafts = _model.GetAllAircraftsForCurrentSelectedAircraftProgrammAndCustomer();
            BuildAndSetAircraftsOnView(_allAircrafts, new AircraftVersionCategoryCriteria());
        }

        private void BuildAndSetAircraftsOnView(List<IAircraft> aircrafts, ICategoryCriteria<IAircraft> categoryCriteria)
        {
            

            var groupedAircrafts =
                from aircraft in aircrafts
                orderby categoryCriteria.GetFilterValue(aircraft)
                group aircraft by categoryCriteria.GetFilterValue(aircraft)
                into aircraftGroup
                select new {Category = aircraftGroup.Key, Products = aircraftGroup};

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
