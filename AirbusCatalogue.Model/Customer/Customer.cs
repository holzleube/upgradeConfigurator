using System.Runtime.Serialization;
using AirbusCatalogue.Common.DataObjects.Customers;
using AirbusCatalogue.Model.Templates;

namespace AirbusCatalogue.Model.Customer
{
    [DataContract]
    public class Customer : Identable, ICustomer
    {
        public Customer(string id, string imagePath, string name):base(id)
        {
            ImagePath = imagePath;
            CustomerName = name;
            CustomerChar = name[0];
        }

        public string ImagePath { get; set; }

        public string CustomerName { get; set; }

        public char CustomerChar { get; set; }
    }
}
