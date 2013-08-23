using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;
using AirbusCatalogue.Common.DataObjects.Aircrafts;
using AirbusCatalogue.Common.DataObjects.Config;
using AirbusCatalogue.Model.Config;
using AirbusCatalogue.Model.Exceptions;
using AirbusCatalogue.ViewModel.Command;
using AirbusCatalogue.ViewModel.Navigation;
using AirbusCatalogue.ViewModel.Templates;
using AirbusCatalogue.ViewModel.ViewDataElements;
using AirbusCatalogue.ViewModel.ViewDataElements.Aircraft;
using AirbusCatalogue.ViewModel.ViewDataElements.Summary;
using AirbusCatalogue.ViewModel.ViewInterfaces;
using AirbusCatalogue.ViewModel.ViewInterfaces.Aircraft;
using AirbusCatalogue.ViewModel.ViewInterfaces.Configuration;
using AirbusCatalogue.ViewModel.ViewInterfaces.Upgrades;
using GalaSoft.MvvmLight.Ioc;


namespace AirbusCatalogue.ViewModel.ViewModel
{
    public class SummaryPageViewModel : GridHolderViewModel
    {
        private const string UpgradeSelectionId = "upgradeSelection";
        private const string AircraftSelectionId = "aircraftSelection";
        private const string AircraftFamilySelectionId = "familySelection";
        private readonly ConfigurationModel _model;
        private ICommand _summaryItemWasSelectedCommand;
        private Dictionary<string, object> _idToPageMappingMap;
        private bool _isBottomAppBarOpen;
        private ICommand _reconfigureCommand;
        private ICommand _navigateToStartCommand;

        public IConfiguration Configuration { get; set; }

        public bool IsBottomAppBarOpen
        {
            get { return _isBottomAppBarOpen; }
            set
            {
                _isBottomAppBarOpen = value;
                OnPropertyChanged();
            }
        }
        public SummaryPageViewModel()
        {
            _model = new ConfigurationModel();
            InitializeIdToPageMappingMap();
        }

        private void SaveConfigurationAndReturnToStartPage(string name)
        {
            if (name == null)
            {
                return;
            }
            
            var message = "Your configuration was ";
            var headline = "";
            if (name.Equals("order"))
            {
                headline = "Order";
                message += "ordered.";
            }
            else
            {
                headline = "Save";
                message += "saved.";
            }
            _model.SaveCurrentConfigurationToFile();
             var messageDialog = new MessageDialog(message,
                headline);
            messageDialog.ShowAsync();
            var startPage = SimpleIoc.Default.GetInstance<IStartScreen>();
            NavigateToClass(startPage, null);
        }

        private void InitializeIdToPageMappingMap()
        {
            _idToPageMappingMap = new Dictionary<string, object>
                {
                    {UpgradeSelectionId, SimpleIoc.Default.GetInstance<IUpgradeTypeSelection>()},
                    {AircraftSelectionId, SimpleIoc.Default.GetInstance<IAircraftVersionSelection>()},
                    {AircraftFamilySelectionId, SimpleIoc.Default.GetInstance<IAircraftFamilySelection>()}
                };
        }

        private void InitializeDataGrid()
        {
            Configuration = _model.GetCurrentConfiguration();
            AddAircraftProgramm(Configuration.Programm);
            ConfigureSelectionIfPossible();
        }

        private void AddConfigurationInProgressTile()
        {
            var configurationGroup = GetConfigurationGroup();
            configurationGroup.Items.Clear();
            configurationGroup.Items.Add(new ConfigureDataItem(configurationGroup));
        }

        private DataGroup GetConfigurationGroup()
        {
            foreach (var summaryPageGroup in DataGroupElements)
            {
                var group = summaryPageGroup as SummaryConfigurationGroup;
                if (group != null)
                {
                    group.ImageContent = Configuration.State.ConfiguationStateIconValue;
                    return group;
                }
            }
            var configurationGroup = new SummaryConfigurationGroup("Configuration", Configuration.State.ConfiguationStateIconValue);
            DataGroupElements.Add(configurationGroup);
            return configurationGroup;
        }

        private void ConfigureSelectionIfPossible()
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
                if (await TryToConfigureConfiguration()) return;
            }
            Configuration = _model.GetCurrentConfiguration();
            group.Items.Clear();
            IsBottomAppBarOpen = true;

            foreach (var configuration in Configuration.ConfigurationGroups)
            {
                group.Items.Add(new ConfigurationGroupDataItem(configuration, group, Configuration.Upgrades.Count));
            }
        }

        private async Task<bool> TryToConfigureConfiguration()
        {
            try
            {
                var configurationTask = _model.ConfigureCurrentConfiguration();
                await configurationTask;
            }
            catch (WebserviceNotAvailableException)
            {
                Configuration.State = ConfigurationState.UNKNOWN;
                var group = GetConfigurationGroup();
                group.Items.Clear();
                group.Items.Add(new UnknownConfigurationDataItem(group));
                return true;
            }
            return false;
        }

       

        private void AddAircraftProgramm(IAircraftProgramm programm)
        {
            var group = new HubDataGroup("aircraft programm goup");
            var aircraftProgramm = new AircraftProgrammDataItem(AircraftFamilySelectionId, programm, group, 60, 60);
            var aircraftSelection = new SummarySelectionDataItem(UpgradeSelectionId, "upgrades", "\uE11C", group, Configuration.Upgrades.Count);
            var upgradeSelection = new SummarySelectionDataItem(AircraftSelectionId, "aircrafts", "\uE0EB", group, Configuration.SelectedAircrafts.Count);
            group.Items.Add(aircraftProgramm);
            group.Items.Add(aircraftSelection);
            group.Items.Add(upgradeSelection);
            DataGroupElements.Add(group);
        }

        public ICommand SummaryItemWasSelectedCommand
        {
            get { return _summaryItemWasSelectedCommand ?? (_summaryItemWasSelectedCommand = new RelayCommand<DataCommon>(SummaryItemWasSelected)); }
        }

        public ICommand ReconfigureCommand
        {
            get { return _reconfigureCommand ?? (_reconfigureCommand = new RelayCommand(ConfigureSelectionIfPossible)); }
        }
        public ICommand NavigateToStartCommand
        {
            get { return _navigateToStartCommand ?? (_navigateToStartCommand = new RelayCommand<string>(SaveConfigurationAndReturnToStartPage)); }
        }

        private void SummaryItemWasSelected(DataCommon dataItem)
        {
            var item = dataItem as BasicDataItem;
            if (item == null)
            {
                return;
            }
            object classToNavigate  = null;
            object parameter = null;
            if (item.Group is HubDataGroup)
            {
                classToNavigate = _idToPageMappingMap[item.UniqueId];
            }
            else if (dataItem is ConfigurationGroupDataItem)
            {
                var configurationDataItem = (ConfigurationGroupDataItem) dataItem;
                var configurationGroup = configurationDataItem.ConfigurationGroup;
                if (
                    configurationGroup.GroupConfigurationState.Equals(
                        ConfigurationState.IMPOSSIBLE))
                {
                    AskUserAndRemoveGroupFromConfiguration(configurationGroup);
                    return;
                }
                classToNavigate = SimpleIoc.Default.GetInstance<IConfigurationAlternativeSelection>();
                parameter = configurationGroup;
            }
            if (classToNavigate == null)
            {
                return;
            }
            NavigateToClass(classToNavigate, parameter);
        }

        private void AskUserAndRemoveGroupFromConfiguration(IConfigurationGroup configurationGroup)
        {
            var messageDialog = new MessageDialog("Do you want to delete this group?",
                "Delete Group " + configurationGroup.Name);
            var command = new UICommandInvokedHandler((IUICommand paramter) =>
            {
                _model.RemoveGroupFromConfiguration(configurationGroup);
                InitializeDataGrid();
            });
            messageDialog.Commands.Add(new UICommand("Yes", command));
        }

        private void NavigateToClass(object classToNavigate, object parameter)
        {
            var navigationService = SimpleIoc.Default.GetInstance<INavigationService>();
            if (parameter == null)
            {
                navigationService.Navigate(classToNavigate.GetType());
                return;
            }
            navigationService.Navigate(classToNavigate.GetType(), parameter);
        }

        public override void Initialize(object parameter)
        {
            var configurationFile = parameter as IConfigurationFile;
            if (configurationFile != null)
            {
                GetDataFromConfigurationFile(configurationFile);
            }
            else
            {
                InitializeDataGrid();
            }
        }

        private async void GetDataFromConfigurationFile(IConfigurationFile configurationFile)
        {
            if (await TryToLoadConfiguration(configurationFile)) return;
        }
        private async Task<bool> TryToLoadConfiguration(IConfigurationFile configurationFile)
        {
            await _model.LoadConfigurationFromFileSystemAndSetItAsCurrentConfiguration(configurationFile.Filename);
            InitializeDataGrid();
            return true;
        }
    }
}
