using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.Common.DataObjects.Upgrades;

namespace AirbusCatalogue.ViewModel.Templates
{
    public interface IUpgradeSelectionViewModel
    {
        ObservableCollection<IUpgradeItem> SelectedUpgradeItems { get; set; }

        void UpdateSelection(IUpgradeItem itemToUpdate, bool isSelected);
    }
}
