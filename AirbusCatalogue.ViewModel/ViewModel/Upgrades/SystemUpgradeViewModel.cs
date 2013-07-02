using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.Common.DataObjects.Upgrades;
using AirbusCatalogue.Model.Upgrades;
using AirbusCatalogue.ViewModel.Templates;

namespace AirbusCatalogue.ViewModel.ViewModel.Upgrades
{
    public class SystemUpgradeViewModel: GridHolderViewModel
    {
        private UpgradeModel _model;

        private ObservableCollection<IAtaChapter> _ataChapters = new ObservableCollection<IAtaChapter>();
        public ObservableCollection<IAtaChapter> AtaChapters
        {
            get { return _ataChapters; } 
            set 
            { 
                _ataChapters = value;
                OnPropertyChanged();
            }
        }

        public IAtaChapter SelectedAtaChapter { 
            get { return _selectedAtaChapter; } 
            set
            {
                _selectedAtaChapter = value;
            } }

        private ObservableCollection<IAtaChapter> _cockpitAtaChapters = new ObservableCollection<IAtaChapter>();
        private IAtaChapter _selectedAtaChapter;

        public ObservableCollection<IAtaChapter> CockpitAtaChapters
        {
            get { return _cockpitAtaChapters; }
            set
            {
                _cockpitAtaChapters = value;
                OnPropertyChanged();
            }
        }

       
        public SystemUpgradeViewModel()
        {
            _model = new UpgradeModel();
        }
        public override void Initialize(object parameter)
        {
            var type = parameter as IUpgradeType;
            if (type == null)
            {
                return;
            }
            var concreteType = _model.GetUpgradeTypeById(type.UniqueId);
            var cockpitAtas = concreteType.AtaChapters.Select(x => x).Where(x => x.Category.Equals("Cockpit")).ToList();
            var completeAtas = concreteType.AtaChapters.Select(x => x).Where(x => x.Category.Equals("Complete")).ToList();
            CockpitAtaChapters = new ObservableCollection<IAtaChapter>(cockpitAtas);
            AtaChapters = new ObservableCollection<IAtaChapter>(completeAtas);
        }
    }
}
