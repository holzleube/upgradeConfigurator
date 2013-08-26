using AirbusCatalogue.Common.DataObjects.Upgrades;
using AirbusCatalogue.Model.Upgrades;
using AirbusCatalogue.ViewModel.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirbusCatalogue.ViewModel.ViewModel.Upgrades
{
    public class CabinDetailUpgradeViewModel:GridHolderViewModel
    {
        private IUpgradeItem _upgradeItem;
        private UpgradeModel _model;

        public CabinDetailUpgradeViewModel()
        {
            _model = new UpgradeModel();
        }
        public override void Initialize(object parameter)
        {
            var upgradeToShow = parameter as IUpgradeItem;
            if (upgradeToShow == null) return;
            InitilizeViewData(upgradeToShow);
        }

        public bool IsUpperDeck
        {
            get
            {
                return _isUpperDeck;
            }
            set
            {
                _isUpperDeck = value;
                OnPropertyChanged();
            }
        }

        public IUpgradeItem UpgradeItem
        {
            get
            {
                return _upgradeItem;
            }
            set
            {
                _upgradeItem = value;
                OnPropertyChanged();
            }
        }

        private void InitilizeViewData(IUpgradeItem upgradeToShow)
        {
            UpgradeItem = upgradeToShow;
        }
    }
}
