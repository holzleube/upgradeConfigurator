using AirbusCatalogue.Model.Aircrafts;
using AirbusCatalogue.ViewModel.Command;
using AirbusCatalogue.ViewModel.Navigation;
using AirbusCatalogue.ViewModel.Templates;
using AirbusCatalogue.ViewModel.ViewDataElements.Aircraft;
using AirbusCatalogue.ViewModel.ViewInterfaces;
using AirbusCatalogue.ViewModel.ViewInterfaces.Aircraft;
using GalaSoft.MvvmLight.Ioc;

namespace AirbusCatalogue.ViewModel.ViewModel.Aircraft
{
    public class SelectAircraftTypeViewModel: GridHolderViewModel
    {
        private AircraftModel _model;
        private RelayCommand<AircraftTypeDataItem> __itemSelected;

        public SelectAircraftTypeViewModel()
        {
            _model = new AircraftModel();
        }

        public override void Initialize(object parameter)
        {
            var typeId = parameter as string;
            var result = _model.GetAircraftTypesByProgramm(typeId);
            foreach (var aircraftType in result) 
            {
                DataGroupElements.Add(new
                AircraftTypeDataItem(aircraftType, null));
            }
        }

        public RelayCommand<AircraftTypeDataItem> ItemSelected {
            get { return __itemSelected ?? (__itemSelected = new RelayCommand<AircraftTypeDataItem>(AircraftTypeWasSelected)); }
        }

        private void AircraftTypeWasSelected(AircraftTypeDataItem item)
        {
            var aircraftVersionSelection = SimpleIoc.Default.GetInstance<IAircraftVersionSelection>();
            var navigationService = SimpleIoc.Default.GetInstance<INavigationService>();
            navigationService.Navigate(aircraftVersionSelection.GetType(), item.DataObject);
        }
    }
}
