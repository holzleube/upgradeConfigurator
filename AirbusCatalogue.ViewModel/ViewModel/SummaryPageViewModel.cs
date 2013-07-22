using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;
using AirbusCatalogue.Common.DataObjects.Aircrafts;
using AirbusCatalogue.Common.DataObjects.Config;
using AirbusCatalogue.Model.Config;
using AirbusCatalogue.ViewModel.Command;
using AirbusCatalogue.ViewModel.Navigation;
using AirbusCatalogue.ViewModel.Templates;
using AirbusCatalogue.ViewModel.ViewDataElements;
using AirbusCatalogue.ViewModel.ViewDataElements.Aircraft;
using AirbusCatalogue.ViewModel.ViewDataElements.Summary;
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

        public IConfiguration Configuration { get; set; }

        public SummaryPageViewModel()
        {
            _model = new ConfigurationModel();
            InitializeIdToPageMappingMap();
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
            SetRightConfigurationStateItem();
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
                var configurationTask= _model.ConfigureCurrentConfiguration();
                Configuration = await configurationTask;
            }
            group.Items.Clear();
            foreach (var configuration in Configuration.ConfigurationGroups)
            {
                group.Items.Add(new ConfigurationGroupDataItem(configuration, group, Configuration.Upgrades.Count));
            }
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
            set
            {
                _summaryItemWasSelectedCommand = value;
                OnPropertyChanged();
            }
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
           
            if (dataItem is ConfigurationGroupDataItem)
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

        private void DeleteGroupFromConfiguration(IUICommand command)
        {
            
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
            InitializeDataGrid();
        }
    }
}
