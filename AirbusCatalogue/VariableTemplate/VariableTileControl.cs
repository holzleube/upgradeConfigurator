using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.Data;
using AirbusCatalogue.DataModel;
using Windows.UI.Xaml.Controls;

namespace AirbusCatalogue.VariableTemplate
{
    class VariableTileControl : GridView
    {
        protected override void PrepareContainerForItemOverride(Windows.UI.Xaml.DependencyObject element, object item)
        {
            if (item.GetType() == typeof(HubPageDataItem))
            {
                var viewModel = item as HubPageDataItem;
                element.SetValue(VariableSizedWrapGrid.ColumnSpanProperty, viewModel.ColSpan);
                element.SetValue(VariableSizedWrapGrid.RowSpanProperty, viewModel.RowSpan);
                base.PrepareContainerForItemOverride(element, item);
                return;
            }
            base.PrepareContainerForItemOverride(element, item);
            
        }
    }
}
