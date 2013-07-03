using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AirbusCatalogue.Common.DataObjects.Upgrades;
using AirbusCatalogue.Model.Upgrades;
using AirbusCatalogue.ViewModel.Command;
using AirbusCatalogue.ViewModel.Navigation;
using AirbusCatalogue.ViewModel.Templates;
using AirbusCatalogue.ViewModel.ViewDataElements;
using AirbusCatalogue.ViewModel.ViewInterfaces.Upgrades;
using GalaSoft.MvvmLight.Ioc;

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

        private ICommand _ataChapterSelectedCommand;
        public ICommand AtaChapterSelectedCommand
        {
            get {
                return _ataChapterSelectedCommand ??
                       (_ataChapterSelectedCommand = new RelayCommand<String>(NavigateToSelectedCommand));
            }
        }

        private void NavigateToSelectedCommand(string ataChapterId)
        {
            var navigationService = SimpleIoc.Default.GetInstance<INavigationService>();
            var ataChapterPage = SimpleIoc.Default.GetInstance<IUpgradeSelection>();
            navigationService.Navigate(ataChapterPage.GetType(), ataChapterId);
        }

        private ICommand _listViewItemWasSelectedCommand;
        public ICommand ListViewItemWasSelectedCommand
        {
            get { return _listViewItemWasSelectedCommand ?? (_listViewItemWasSelectedCommand = new RelayCommand<IAtaChapter>(ListViewItemWasSelected)); }
            
        }

        private void ListViewItemWasSelected(IAtaChapter obj)
        {
            NavigateToSelectedCommand(obj.AtaChapterNumber + " "+ obj.Name);
        }

        public IAtaChapter SelectedAtaChapter { get; set; }

        private ObservableCollection<IAtaChapter> _cockpitAtaChapters = new ObservableCollection<IAtaChapter>();

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
