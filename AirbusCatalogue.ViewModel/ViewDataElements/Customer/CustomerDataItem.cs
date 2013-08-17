namespace AirbusCatalogue.ViewModel.ViewDataElements.Customer
{
    public class CustomerDataItem:BasicDataItem
    {
        public CustomerDataItem(Model.Customer.Customer customer, DataGroup @group) : base(customer.UniqueId, customer.CustomerName, customer.ImagePath, @group, 20, 40)
        {
            

        }

    }
}
