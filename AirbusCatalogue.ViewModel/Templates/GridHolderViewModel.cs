using System.Collections.ObjectModel;
using AirbusCatalogue.Common.DataObjects.General;

namespace AirbusCatalogue.ViewModel.Templates
{
    /// <summary>
    /// This general ViewModel holds a List for a GridView. It should be used from all viewModels, which needs
    /// to hold data for a gridView on a page.
    /// </summary>
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
