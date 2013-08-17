using System.Collections.ObjectModel;
using AirbusCatalogue.Common.DataObjects.General;

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
