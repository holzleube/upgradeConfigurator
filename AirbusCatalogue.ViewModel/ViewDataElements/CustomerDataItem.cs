using AirbusCatalogue.Model.Customer;
using AirbusCatalogue.Model.CustomerModel;

namespace AirbusCatalogue.ViewModel.ViewDataElements
{
    public class CustomerDataItem:BasicDataItem
    {
        public CustomerDataItem(Customer customer, DataGroup @group) : base(customer.UniqueId, customer.CustomerName, customer.ImagePath, @group, 20, 40)
        {
            IsTextVisible = customer.IsTextVisible;

        }

        public bool IsTextVisible { get; set; }
    }
}
