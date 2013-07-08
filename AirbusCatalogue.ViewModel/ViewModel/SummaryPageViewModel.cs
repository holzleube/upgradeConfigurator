﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using AirbusCatalogue.Common.DataObjects.Aircrafts;
using AirbusCatalogue.Common.DataObjects.Config;
using AirbusCatalogue.Model.Config;
using AirbusCatalogue.ViewModel.Command;
using AirbusCatalogue.ViewModel.Navigation;
using AirbusCatalogue.ViewModel.Templates;
using AirbusCatalogue.ViewModel.ViewDataElements;
using AirbusCatalogue.ViewModel.ViewDataElements.Aircraft;
using AirbusCatalogue.ViewModel.ViewDataElements.Configuration;
using AirbusCatalogue.ViewModel.ViewDataElements.Summary;
using AirbusCatalogue.ViewModel.ViewInterfaces.Aircraft;
using AirbusCatalogue.ViewModel.ViewInterfaces.Upgrades;
using GalaSoft.MvvmLight.Ioc;


namespace AirbusCatalogue.ViewModel.ViewModel
{
    public class SummaryPageViewModel : GridHolderViewModel
    {
        private readonly ConfigurationModel _model;
        private ICommand _selectAircraftCommand;
        private ICommand _selectUpgradeCommand;

        public IConfiguration Configuration { get; set; }


        public SummaryPageViewModel()
        {
            _model = new ConfigurationModel();
            InitializeDataGrid();
            
        }

        private void InitializeDataGrid()
        {
            Configuration = _model.GetCurrentConfiguration();
            AddAircraftProgramm(Configuration.Programm);
            AddAircraftGroup(Configuration.SelectedAircrafts);
        }

        private void AddAircraftProgramm(IAircraftProgramm programm)
        {
            var group = new HubDataGroup("aircraft programm goup");
            var aircraftProgramm = new AircraftProgrammDataItem(programm, group, 60, 60);
            var aircraftSelection = new SummarySelectionDataItem("aircraftSelection", "upgrades", "\uE11C", group, Configuration.Upgrades.Count);
            var upgradeSelection = new SummarySelectionDataItem("aircraftSelection", "aircrafts", "\uE0EB", group, Configuration.SelectedAircrafts.Count);
            group.Items.Add(aircraftProgramm);
            group.Items.Add(aircraftSelection);
            group.Items.Add(upgradeSelection);
            DataGroupElements.Add(group);
        }

        private void AddAircraftGroup(List<IAircraft> aircrafts)
        {
            if (aircrafts.Count == 0)
            {
                return;
            }
            var aircraftGroup = new ConfigurationGroup("selectedAircraftGroup", "selected aircrafts", "&#xE0EB;");
            var aircraftItems = GetSelectedAircraftItemsOrderedByVersions(aircrafts, aircraftGroup);
            aircraftGroup.Items = aircraftItems;
            DataGroupElements.Add(aircraftGroup);
        }

        private ObservableCollection<BasicDataItem> GetSelectedAircraftItemsOrderedByVersions(IEnumerable<IAircraft> aircrafts, DataGroup aircraftGroup)
        {
            var aircraftsByCategory = aircrafts.GroupBy(x => x.Version)
                .Select(x => new AircraftVersionSelectionGroup(aircraftGroup, x.ToList()));
            return new ObservableCollection<BasicDataItem>(aircraftsByCategory);
        }

        public ICommand SelectAircraftCommand
        {
            get { return _selectAircraftCommand ?? (_selectAircraftCommand = new RelayCommand(NavigateToSelectAircraft)); }
            set 
            { 
                _selectAircraftCommand = value;
                OnPropertyChanged();
            }
        }
        
        public ICommand SelectUpgradeCommand
        {
            get { return _selectUpgradeCommand ?? (_selectUpgradeCommand = new RelayCommand(NavigateToSelectUpgrade)); }
            set 
            {
                _selectUpgradeCommand = value;
                OnPropertyChanged();
            }
        }

        private void NavigateToSelectUpgrade()
        {
            var classToNavigate = SimpleIoc.Default.GetInstance<IUpgradeTypeSelection>();
            NavigateToClass(classToNavigate, null);
        }

        private void NavigateToSelectAircraft()
        {
            var classToNavigate = SimpleIoc.Default.GetInstance<IAircraftVersionSelection>();
            NavigateToClass(classToNavigate, Configuration.Programm);
        }

        private void NavigateToClass(object classToNavigate, object parameter)
        {
            var navigationService = SimpleIoc.Default.GetInstance<INavigationService>();
            navigationService.Navigate(classToNavigate.GetType(),parameter);
        }

        public override void Initialize(object parameter)
        {

        }
    }
}
