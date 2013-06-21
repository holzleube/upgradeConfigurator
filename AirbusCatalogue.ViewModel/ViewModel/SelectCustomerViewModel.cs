
using System.Collections.Generic;
using System.Collections.ObjectModel;
using AirbusCatalogue.Model.CustomerModel;
using AirbusCatalogue.ViewModel.Converter;
using AirbusCatalogue.ViewModel.Templates;
using AirbusCatalogue.ViewModel.ViewDataElements;

namespace AirbusCatalogue.ViewModel.ViewModel
{
    public class SelectCustomerViewModel:BindableBase
    {
        public SelectCustomerViewModel()
        {
            AppName = "select customer";
            _customerModel = new CustomerModel();
            InitializeCustomers();
        }

        private void InitializeCustomers()
        {
            var allCustomers = _customerModel.AllCustomers;
            CustomerCollection = new ModelObjectsToViewObjectsConverter().GetConvertedElements(allCustomers);
        }

        public ObservableCollection<DataGroup> CustomerCollection
        {
            get
            {
                return _customerCollection;
            }
            set
            {
                _customerCollection = value;
                OnPropertyChanged();
            }
        }

        private string _appName;
        private readonly CustomerModel _customerModel;
        private ObservableCollection<DataGroup> _customerCollection;

        public string AppName
        {
            get
            {
                return _appName;
            }
            set { 
                _appName = value;
                OnPropertyChanged();
            }
        }
    }
}
