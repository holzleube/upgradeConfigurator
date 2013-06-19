using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.Model.CustomerModel;
using AirbusCatalogue.ViewModel.ViewDataElements;

namespace AirbusCatalogue.ViewModel.Converter
{
    public class ModelObjectsToViewObjectsConverter
    {
        public ObservableCollection<SampleDataGroup> GetConvertedElements(ICollection<Customer> allCustomers)
        {
            var result = new ObservableCollection<SampleDataGroup>();
            var groupA = new SampleDataGroup("firstGroup", "A", "MyFirstGroup", "Assets/DarkGray.png", "basisGruppe");

            var groupToCharDictionary = new Dictionary<Char, SampleDataGroup>();
           
            foreach (var customer in allCustomers)
            {
                SampleDataGroup group;
                try
                {
                   group  = groupToCharDictionary[customer.CustomerChar];
                }
                catch (KeyNotFoundException)
                {
                    group = new SampleDataGroup("group" + customer.CustomerChar, customer.CustomerChar.ToString(), "", "Assets/DarkGray.png", "");
                    groupToCharDictionary.Add(customer.CustomerChar, group);
                    result.Add(group);
                }
                group.Items.Add(new CustomerDataItem(customer, groupA));

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
