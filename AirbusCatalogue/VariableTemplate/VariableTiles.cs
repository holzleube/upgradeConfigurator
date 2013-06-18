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
        public DataTemplate UpgradeTemplate { get; set; }
        public DataTemplate UpgradeTemplateMiddle { get; set; }
        public DataTemplate UpgradeTemplateSmall { get; set; }
        public DataTemplate LifeTemplate { get; set; }
        public DataTemplate MultimediaTemplate { get; set; }
        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            var element = container as FrameworkElement;
            if (element != null && item != null)
            {
                if (item.GetType() == typeof(HubPageDataItem))
                {
                        return TopTemplate;
                }
                if (item.GetType() == typeof(NewUpgradeDataItem))
                {
                    switch ((item as NewUpgradeDataItem).TileSize)
                    {
                        case Size.Big:
                            return UpgradeTemplate;
                        case Size.Middle:
                            return UpgradeTemplateMiddle;
                        case Size.Small:
                            return UpgradeTemplateSmall;
                        default:
                            return UpgradeTemplateSmall;
                    }
                }
                return SmallTemplate;

                //if ((item as CategoryDataItem).UniqueId.StartsWith("Top"))
                //    return TopTemplate;
                //if ((item as CategoryDataItem).UniqueId.StartsWith("Small"))
                //    return SmallTemplate;
                //if ((item as CategoryDataItem).UniqueId.StartsWith("World"))
                //    return UpgradeTemplate;
                //if ((item as CategoryDataItem).UniqueId.StartsWith("life"))
                //    return LifeTemplate;
                //if ((item as CategoryDataItem).UniqueId.StartsWith("Multimedia"))
                //    return MultimediaTemplate;


            }
            return base.SelectTemplateCore(item, container);
        }
    }
}
