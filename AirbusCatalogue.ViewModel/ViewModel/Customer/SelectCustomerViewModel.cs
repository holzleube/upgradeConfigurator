using System.Collections.ObjectModel;
using System.Linq;
using AirbusCatalogue.Common.DataObjects.General;
using AirbusCatalogue.Model.Customer;
using AirbusCatalogue.ViewModel.Converter;
using AirbusCatalogue.ViewModel.Templates;
using AirbusCatalogue.ViewModel.ViewDataElements;

namespace AirbusCatalogue.ViewModel.ViewModel.Customer
{
    public class SelectCustomerViewModel:GridHolderViewModel
    {
        private readonly CustomerInformationModel _customerModel;
        public SelectCustomerViewModel()
        {
            Headline = "select customer";
            _customerModel = new CustomerInformationModel();
            InitializeCustomers();
        }

        private void InitializeCustomers()
        {
            DataGroupElements = new ObservableCollection<IIdentable>();
            var allCustomers = _customerModel.GetAllCustomers();
            var groupedCustomers =
                from w in allCustomers
                orderby w.CustomerChar
                group w by w.CustomerChar
                    into g
                    select new { Category = g.Key, Customers = g };
            foreach (var g in groupedCustomers)
            {
                var group = new DataGroup("customerGroup" + g.Category, g.Category.ToString(), "");
                group.Items = new ObservableCollection<IIdentable>(g.Customers.ToList());
                DataGroupElements.Add(group);
            }
            
        }


        public override void Initialize(object parameter)
        {
            
        }
    }
}
