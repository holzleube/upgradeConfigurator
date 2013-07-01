using AirbusCatalogue.Model.CustomerModel;
using AirbusCatalogue.ViewModel.Converter;
using AirbusCatalogue.ViewModel.Templates;

namespace AirbusCatalogue.ViewModel.ViewModel.Customer
{
    public class SelectCustomerViewModel:GridHolderViewModel
    {
        private readonly CustomerModel _customerModel;
        public SelectCustomerViewModel()
        {
            Headline = "select customer";
            _customerModel = new CustomerModel();
            InitializeCustomers();
        }

        private void InitializeCustomers()
        {
            var allCustomers = _customerModel.AllCustomers;
            DataGroupElements = new ModelObjectsToViewObjectsConverter().GetConvertedElements(allCustomers);
        }


        public override void Initialize(object parameter)
        {
            
        }
    }
}
