using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.DataModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace AirbusCatalogue.VariableTemplate
{
    public class VariableHeader: DataTemplateSelector
    {
        public DataTemplate TopTemplate { get; set; }
        public DataTemplate SmallTemplate { get; set; }
        
        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            var element = container as FrameworkElement;
            if (element != null && item != null)
            {
                if (item.GetType() == typeof(HubDataGroup))
                {
                    return TopTemplate;
                }
                return SmallTemplate;

                //if ((item as CategoryDataItem).UniqueId.StartsWith("Top"))
                //    return TopTemplate;
                //if ((item as CategoryDataItem).UniqueId.StartsWith("Small"))
                //    return SmallTemplate;
                //if ((item as CategoryDataItem).UniqueId.StartsWith("World"))
                //    return UpgradeTemplate;
                //if ((item as CategoryDataItem).UniqueId.StartsWith("life"))
                //    return ConfigurationTemplate;
                //if ((item as CategoryDataItem).UniqueId.StartsWith("Multimedia"))
                //    return MultimediaTemplate;


            }
            return base.SelectTemplateCore(item, container);
        }
    }
}
