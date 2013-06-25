using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.Model.Aircrafts;
using AirbusCatalogue.ViewModel.Templates;
using AirbusCatalogue.ViewModel.ViewDataElements;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace AirbusCatalogue.ViewModel.ViewModel
{
    public class SelectAircraftViewModel : GridHolderViewModel
    {
        private AircraftModel _model;

        public SelectAircraftViewModel()
        {
            Headline = "select aircraft family";
            _model = new AircraftModel();
            InitializeDataSource();
        }

        private void InitializeDataSource()
        {

            DataGroupElements = new ObservableCollection<DataCommon>
                {
                    new AircraftProgrammGroup(_model.GetAllAircraftProgramms())
                };

            
        }

        public override void Initialize(object parameter)
        {
            
        }
    }
}
