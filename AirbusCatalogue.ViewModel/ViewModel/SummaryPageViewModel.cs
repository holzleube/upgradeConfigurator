using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using AirbusCatalogue.Common.DataObjects.Aircrafts;
using AirbusCatalogue.Common.DataObjects.Config;
using AirbusCatalogue.Common.DataObjects.General;
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
        private const string UpgradeSelectionId = "upgradeSelection";
        private const string AircraftSelectionId = "aircraftSelection";
        private readonly ConfigurationModel _model;
        private ICommand _summaryItemWasSelectedCommand;

        public IConfiguration Configuration { get; set; }

        public SummaryPageViewModel()
        {
            _model = new ConfigurationModel();  
        }

        private void InitializeDataGrid()
        {
            Configuration = _model.GetCurrentConfiguration();
            AddAircraftProgramm(Configuration.Programm);
            AddConfigurationGroup();
        }

        private void AddConfigurationInProgressTile()
        {
            var configurationGroup = GetConfigurationGroup();
            configurationGroup.Items.Clear();
            configurationGroup.Items.Add(new ConfigureDataItem(configurationGroup));
        }

        private void AddConfigurationGroup()
        {
            SetRightConfigurationStateItem();
        }

        private DataGroup GetConfigurationGroup()
        {
            foreach (var summaryPageGroup in DataGroupElements)
            {
                var group = summaryPageGroup as SummaryConfigurationGroup;
                if (group != null)
                {
                    return group;
                }
            }
            var configurationGroup = new SummaryConfigurationGroup("Configuration", "\uE15E");
            DataGroupElements.Add(configurationGroup);
            return configurationGroup;
        }

        private void SetRightConfigurationStateItem()
        {
            var group = GetConfigurationGroup();
            if (Configuration.SelectedAircrafts.Count > 0 && Configuration.Upgrades.Count > 0)
            {
                AddConfigurationInProgressTile();
                CalculateConfigurationAndGetConfigurationGroup();
                return;
            }
            group.Items.Add(new IncompleteConfigurationDataItem(group));
        }

        private async void CalculateConfigurationAndGetConfigurationGroup()
        {
            var group = GetConfigurationGroup();
            if (Configuration.HasConfigurationChanged)
            {
                Task<IConfiguration> configurationTask= _model.ConfigureCurrentConfiguration();
                Configuration = await configurationTask;
            }
            group.Items.Clear();
            foreach (var configuration in Configuration.ConfigurationGroups)
            {
                group.Items.Add(new ConfigurationGroupDataItem(configuration, group));
            }
        }

        private void AddAircraftProgramm(IAircraftProgramm programm)
        {
            var group = new HubDataGroup("aircraft programm goup");
            var aircraftProgramm = new AircraftProgrammDataItem(programm, group, 60, 60);
            var aircraftSelection = new SummarySelectionDataItem(UpgradeSelectionId, "upgrades", "\uE11C", group, Configuration.Upgrades.Count);
            var upgradeSelection = new SummarySelectionDataItem(AircraftSelectionId, "aircrafts", "\uE0EB", group, Configuration.SelectedAircrafts.Count);
            group.Items.Add(aircraftProgramm);
            group.Items.Add(aircraftSelection);
            group.Items.Add(upgradeSelection);
            DataGroupElements.Add(group);
        }

        //private void AddAircraftGroup(List<IAircraft> aircrafts)
        //{
        //    if (aircrafts.Count == 0)
        //    {
        //        return;
        //    }
        //    var aircraftGroup = new ConfigurationGroup("selectedAircraftGroup", "selected aircrafts", "&#xE0EB;");
        //    var aircraftItems = GetSelectedAircraftItemsOrderedByVersions(aircrafts, aircraftGroup);
        //    aircraftGroup.Items = aircraftItems;
        //    DataGroupElements.Add(aircraftGroup);
        //}

        private ObservableCollection<BasicDataItem> GetSelectedAircraftItemsOrderedByVersions(IEnumerable<IAircraft> aircrafts, DataGroup aircraftGroup)
        {
            var aircraftsByCategory = aircrafts.GroupBy(x => x.Version)
                .Select(x => new AircraftVersionSelectionGroup(aircraftGroup, x.ToList()));
            return new ObservableCollection<BasicDataItem>(aircraftsByCategory);
        }

        public ICommand SummaryItemWasSelectedCommand
        {
            get { return _summaryItemWasSelectedCommand ?? (_summaryItemWasSelectedCommand = new RelayCommand<DataCommon>(SummaryItemWasSelected)); }
            set
            {
                _summaryItemWasSelectedCommand = value;
                OnPropertyChanged();
            }
        }

        private void SummaryItemWasSelected(DataCommon dataItem)
        {
            if (dataItem.UniqueId.Equals(AircraftSelectionId))
            {
                NavigateToSelectAircraft();
            }
            if (dataItem.UniqueId.Equals(UpgradeSelectionId))
            {
                NavigateToSelectUpgrade();
            }
            if (dataItem.UniqueId.Equals(Configuration.Programm.UniqueId))
            {
                NavigateToSelectAircraftFamily();
            }
            
        }

        private void NavigateToSelectAircraftFamily()
        {
            var classToNavigate = SimpleIoc.Default.GetInstance<IAircraftFamilySelection>();
            NavigateToClass(classToNavigate, null);
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
            InitializeDataGrid();
        }
    }
}
