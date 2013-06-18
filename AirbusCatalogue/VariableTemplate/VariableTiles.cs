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
    public class VariableTiles : DataTemplateSelector
    {
        public DataTemplate TopTemplate { get; set; }
        public DataTemplate SmallTemplate { get; set; }
        public DataTemplate WorldNewsBigImageTemplate { get; set; }
        public DataTemplate LifeTemplate { get; set; }
        public DataTemplate MultimediaTemplate { get; set; }
        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;
            if (element != null && item != null)
            {
                if (item.GetType() == typeof(HubPageDataItem))
                {
                   
                        return TopTemplate;
                }
                return SmallTemplate;

                //if ((item as CategoryDataItem).UniqueId.StartsWith("Top"))
                //    return TopTemplate;
                //if ((item as CategoryDataItem).UniqueId.StartsWith("Small"))
                //    return SmallTemplate;
                //if ((item as CategoryDataItem).UniqueId.StartsWith("World"))
                //    return WorldNewsBigImageTemplate;
                //if ((item as CategoryDataItem).UniqueId.StartsWith("life"))
                //    return LifeTemplate;
                //if ((item as CategoryDataItem).UniqueId.StartsWith("Multimedia"))
                //    return MultimediaTemplate;


            }
            return base.SelectTemplateCore(item, container);
        }
    }
}
