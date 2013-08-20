using System.Runtime.Serialization;
using AirbusCatalogue.Common.DataObjects.Customers;
using AirbusCatalogue.Model.Templates;
using AirbusCatalogue.Common.DataObjects.General;

namespace AirbusCatalogue.Model.Customer
{
    [DataContract]
    public class Customer : IIdentable, ICustomer
    {
        public Customer(string id, string imagePath, string name)
        {
            ImagePath = imagePath;
            CustomerName = name;
            CustomerChar = name[0];
            UniqueId = id;
        }

        [DataMember]
        public string ImagePath { get; set; }

        [DataMember]
        public string CustomerName { get; set; }

        [DataMember]
        public char CustomerChar { get; set; }

        [DataMember]
        public string UniqueId { get; set; }
    }
}
