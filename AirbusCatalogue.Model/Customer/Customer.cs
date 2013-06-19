using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirbusCatalogue.Model.CustomerModel
{
    public class Customer
    {
        public Customer(string id, string imagePath, string name, bool isTextVisible)
        {
            UniqueId = id;
            ImagePath = imagePath;
            CustomerName = name;
            IsTextVisible = isTextVisible;
            CustomerChar = name[0];
        }

        public string UniqueId { get; set; }

        public string ImagePath { get; set; }

        public string CustomerName { get; set; }

        public bool IsTextVisible { get; set; }

        public char CustomerChar { get; set; }
    }
}
