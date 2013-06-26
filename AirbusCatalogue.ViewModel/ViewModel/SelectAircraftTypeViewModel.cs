using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.Model.Aircrafts;
using AirbusCatalogue.ViewModel.Command;
using AirbusCatalogue.ViewModel.Navigation;
using AirbusCatalogue.ViewModel.Templates;
using AirbusCatalogue.ViewModel.ViewDataElements;
using AirbusCatalogue.ViewModel.ViewInterfaces;
using GalaSoft.MvvmLight.Ioc;

namespace AirbusCatalogue.ViewModel.ViewModel
{
    public class SelectAircraftTypeViewModel: GridHolderViewModel
    {
        private AircraftModel _model;
        private RelayCommand __itemSelected;

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
                BasicDataItem(aircraftType.UniqueId, aircraftType.Name,aircraftType.ImagePath, null, 60, 80));
            }
        }

        public RelayCommand ItemSelected { 
            get { return __itemSelected ?? (__itemSelected = new RelayCommand(AircraftTypeWasSelected)); }
        }

        private void AircraftTypeWasSelected()
        {
            var aircraftVersionSelection = SimpleIoc.Default.GetInstance<IAircraftVersionSelection>();
            var navigationService = SimpleIoc.Default.GetInstance<INavigationService>();
            navigationService.Navigate(aircraftVersionSelection.GetType(), "");
        }
    }
}
