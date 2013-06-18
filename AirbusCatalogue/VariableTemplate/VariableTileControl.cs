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
            try
            {
                dynamic _Item = item;
                element.SetValue(VariableSizedWrapGrid.ColumnSpanProperty, _Item.ColSpan);
                element.SetValue(VariableSizedWrapGrid.RowSpanProperty, _Item.RowSpan);
                base.PrepareContainerForItemOverride(element, item);
            }
            catch
            {
                element.SetValue(VariableSizedWrapGrid.ColumnSpanProperty, 1);
                element.SetValue(VariableSizedWrapGrid.RowSpanProperty, 1);
            }
            finally
            {
                base.PrepareContainerForItemOverride(element, item);
            }
            
        }
    }
}
