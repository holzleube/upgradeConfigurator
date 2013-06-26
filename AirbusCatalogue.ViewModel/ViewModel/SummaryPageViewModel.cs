using System.Collections.ObjectModel;
using System.Windows.Input;
using AirbusCatalogue.Model.Aircrafts;
using AirbusCatalogue.Model.Config;
using AirbusCatalogue.Model.ConfigurationData;
using AirbusCatalogue.ViewModel.Command;
using AirbusCatalogue.ViewModel.Navigation;
using AirbusCatalogue.ViewModel.Templates;
using AirbusCatalogue.ViewModel.ViewDataElements;
using AirbusCatalogue.ViewModel.ViewDataElements.Configuration;
using AirbusCatalogue.ViewModel.ViewInterfaces;
using GalaSoft.MvvmLight.Ioc;


namespace AirbusCatalogue.ViewModel.ViewModel
{
    public class SummaryPageViewModel : GridHolderViewModel
    {
        private readonly ConfigurationModel _model;
        private ICommand _selectAircraftCommand;
        private Configuration _configuration;


        public SummaryPageViewModel()
        {
            _model = new ConfigurationModel();
            InitializeDataGrid();
            
        }

        private void InitializeDataGrid()
        {
            _configuration = _model.GetCurrentConfiguration();
            var programmGroup = GetProgrammGroup(_configuration.Programm);

            DataGroupElements.Add(programmGroup);
        }

        private ConfigurationGroup GetProgrammGroup(AircraftProgramm programm)
        {
            var group = new ConfigurationGroup("aircraftProgrammGroup", "aircraft family", "&#xE093;");
            group.Items.Add(new BasicDataItem(programm.UniqueId, programm.Name, programm.ImagePath, group, 60, 80));
            return group;
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

        private void NavigateToSelectAircraft()
        {
            object classToNavigate;
            if (_configuration.Programm.UniqueId.Equals("R-Series"))
            {
                classToNavigate = SimpleIoc.Default.GetInstance<IAircraftVersionSelection>();
            }
            else
            {
                classToNavigate = SimpleIoc.Default.GetInstance<IAircraftTypeSelection>();
            }
            var navigationService = SimpleIoc.Default.GetInstance<INavigationService>();
            navigationService.Navigate(classToNavigate.GetType(), _configuration.Programm.UniqueId);
        }

        public override void Initialize(object parameter)
        {

        }
    }
}
