using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.Common.DataObjects.General;
using AirbusCatalogue.Model.CustomerModel;
using AirbusCatalogue.ViewModel.ViewDataElements;

namespace AirbusCatalogue.ViewModel.Templates
{
    public abstract class GridHolderViewModel : ViewModelBase
    {
        private string _headline;
       

        public string Headline
        {
            get
            {
                return _headline;
            }
            set
            {
                _headline = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<IIdentable> _dataGroupElements = new ObservableCollection<IIdentable>();
        public ObservableCollection<IIdentable> DataGroupElements
        {
            get
            {
                return _dataGroupElements;
            }
            set
            {
                _dataGroupElements = value;
                OnPropertyChanged();
            }
        }
    }
}
