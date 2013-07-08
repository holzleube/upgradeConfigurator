using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.ViewModel.ViewDataElements.Aircraft;
using AirbusCatalogue.ViewModel.ViewDataElements.Customer;
using AirbusCatalogue.ViewModel.ViewDataElements.Summary;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace AirbusCatalogue.VariableTemplate
{
    class SummaryTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ProgrammTile { get; set; }
        public DataTemplate AircraftTile { get; set; }
        public DataTemplate SelectionTile { get; set; }
        public DataTemplate ConfigurationTile { get; set; }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            var element = container as FrameworkElement;
            if (element == null || item == null)
            {
                return base.SelectTemplateCore(item, container);
            }
            if (item.GetType() == typeof(AircraftProgrammDataItem))
            {
                return ProgrammTile;
            }
            if (item.GetType() == typeof(AircraftVersionSelectionGroup))
            {
                return AircraftTile;
            }
            if (item.GetType() == typeof(SummarySelectionDataItem))
            {
                return SelectionTile;
            }
            return base.SelectTemplateCore(item, container);

        }
    }
}
