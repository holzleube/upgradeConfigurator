using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.Model.Aircrafts;
using AirbusCatalogue.ViewModel.Templates;
using AirbusCatalogue.ViewModel.ViewDataElements;

namespace AirbusCatalogue.ViewModel.ViewModel
{
    public class SelectAircraftTypeViewModel: GridHolderViewModel
    {
        private AircraftModel _model;

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
    }
}
