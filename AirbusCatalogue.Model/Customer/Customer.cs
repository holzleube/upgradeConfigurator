﻿using AirbusCatalogue.Model.Templates;

namespace AirbusCatalogue.Model.Customer
{
    public class Customer : Identable, ICustomer
    {
        public Customer(string id, string imagePath, string name, bool isTextVisible):base(id)
        {
            ImagePath = imagePath;
            CustomerName = name;
            IsTextVisible = isTextVisible;
            CustomerChar = name[0];
        }

        public string ImagePath { get; set; }

        public string CustomerName { get; set; }

        public bool IsTextVisible { get; set; }

        public char CustomerChar { get; set; }
    }
}
