using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.Model.Customer;
using AirbusCatalogue.Model.CustomerModel;
using AirbusCatalogue.ViewModel.ViewDataElements;

namespace AirbusCatalogue.ViewModel.Converter
{
    public class ModelObjectsToViewObjectsConverter
    {
        public ObservableCollection<DataGroup> GetConvertedElements(ICollection<Customer> allCustomers)
        {
            var result = new ObservableCollection<DataGroup>();
           
            var groupToCharDictionary = new Dictionary<Char, DataGroup>();
           
            foreach (var customer in allCustomers)
            {
                DataGroup group;
                try
                {
                   group  = groupToCharDictionary[customer.CustomerChar];
                }
                catch (KeyNotFoundException)
                {
                    group = new DataGroup("group" + customer.CustomerChar, customer.CustomerChar.ToString(),  "Assets/DarkGray.png", "");
                    groupToCharDictionary.Add(customer.CustomerChar, group);
                    result.Add(group);
                }
                group.Items.Add(new CustomerDataItem(customer, group));

            }


           
            return result;
        }

        public class GroupInfoList<T> : List<object>
        {

            public object Key { get; set; }


            public new IEnumerator<object> GetEnumerator()
            {
                return (System.Collections.Generic.IEnumerator<object>)base.GetEnumerator();
            }
        }

       
       
    }
}
