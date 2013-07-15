using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
        private const string FamilySelectionId = "familySelection";
        private readonly ConfigurationModel _model;
        private ICommand _summaryItemWasSelectedCommand;
        private bool _isProgressBarVisible =false;

        public IConfiguration Configuration { get; set; }


        public SummaryPageViewModel()
        {
            _model = new ConfigurationModel();
            InitializeDataGrid();
            
        }

        public bool IsProgressBarVisible
        {
            get { return _isProgressBarVisible; }
            set 
            { 
                _isProgressBarVisible = value;
                OnPropertyChanged();
            }
        }

        private void InitializeDataGrid()
        {
            IsProgressBarVisible = true;
            var configurationGroup = GetEmptyConfigurationGroup();
            configurationGroup.Items.Add(new ConfigureDataItem(configurationGroup));
            DataGroupElements.Add(configurationGroup);
            Configuration = _model.GetCurrentConfiguration();
            AddAircraftProgramm(Configuration.Programm);
            AddConfigurationGroup();
            AddAircraftGroup(Configuration.SelectedAircrafts);
        }

        private void AddConfigurationGroup()
        {
            var emptyConfigurationGroup = GetEmptyConfigurationGroup();

            var configurationGroup = GetRightConfigurationStateItem(emptyConfigurationGroup);
            DataGroupElements.Add(configurationGroup);
        }

        private static SummaryConfigurationGroup GetEmptyConfigurationGroup()
        {
            return new SummaryConfigurationGroup("Configuration", "\uE11C");
        }

        private DataGroup GetRightConfigurationStateItem(DataGroup group)
        {
            if (Configuration.SelectedAircrafts.Count > 0 && Configuration.Upgrades.Count > 0)
            {
                return CalculateConfigurationAndGetConfigurationGroup(group);
            }
            group.Items.Add(new IncompleteConfigurationDataItem(group));
            return group;
        }

        private DataGroup CalculateConfigurationAndGetConfigurationGroup(DataGroup group)
        {
            IsProgressBarVisible = true;
            
            if (Configuration.HasConfigurationChanged)
            {
                Configuration = _model.ConfigureCurrentConfiguration();
            }
            foreach (var configuration in Configuration.ConfigurationGroups)
            {
                group.Items.Add(new ConfigurationGroupDataItem(configuration, group));
            }
            IsProgressBarVisible = false;
            return group;
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

        }
    }
}
