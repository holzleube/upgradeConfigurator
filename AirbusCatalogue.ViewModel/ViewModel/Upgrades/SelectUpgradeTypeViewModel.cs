using System.Collections.ObjectModel;
using System.Windows.Input;
using AirbusCatalogue.Common.BasicData;
using AirbusCatalogue.Common.DataObjects.Upgrades;
using AirbusCatalogue.Model.Upgrades;
using AirbusCatalogue.ViewModel.Command;
using AirbusCatalogue.ViewModel.Navigation;
using AirbusCatalogue.ViewModel.Templates;
using AirbusCatalogue.ViewModel.ViewInterfaces.Upgrades;
using GalaSoft.MvvmLight.Ioc;

namespace AirbusCatalogue.ViewModel.ViewModel.Upgrades
{
    public class SelectUpgradeTypeViewModel:BindableBase
    {
        public SelectUpgradeTypeViewModel()
        {
            _model = new UpgradeModel();
            InitializeCabinAndSystemGrids();
        }

        private void InitializeCabinAndSystemGrids()
        {
            SystemAtaChapters = new ObservableCollection<IAtaChapter>(_model.GetUpgradeTypeById("system").AtaChapters);
            CabinAtaChapters = new ObservableCollection<IAtaChapter>(_model.GetUpgradeTypeById("cabin").AtaChapters);
        }

        private ICommand _upgradeTypeSelectedCommand;
        private readonly UpgradeModel _model;
        private ObservableCollection<IAtaChapter> _systemAtaChapters;
        private ObservableCollection<IAtaChapter> _cabinAtaChapters;

        public ICommand UpgradeTypeSelectedCommand
        {
            get { return _upgradeTypeSelectedCommand ?? (_upgradeTypeSelectedCommand = new RelayCommand<string>(NavigateToRightType)); }
            set
            {
                _upgradeTypeSelectedCommand = value;
                OnPropertyChanged();
            }
        }

        private ICommand _subAtaChapterWasSelectedCommand;
        public ICommand SubAtaChapterWasSelectedCommand
        {
            get { return _subAtaChapterWasSelectedCommand ?? (_subAtaChapterWasSelectedCommand = new RelayCommand<IAtaChapter>(SubAtaChapterWasSelected)); }

        }

        private void SubAtaChapterWasSelected(IAtaChapter ataChapter)
        {
            var ataChapterPage = SimpleIoc.Default.GetInstance<IUpgradeSelection>();
            GetNavigationService().Navigate(ataChapterPage.GetType(), ataChapter);
        }


        private void NavigateToRightType(string obj)
        {
            var type = _model.GetUpgradeTypeById(obj);
            var typePage = SimpleIoc.Default.GetInstance<ISystemUpgrade>();
            GetNavigationService().Navigate(typePage.GetType(), type);
        }

        private static INavigationService GetNavigationService()
        {
            return SimpleIoc.Default.GetInstance<INavigationService>();
        }

        public ObservableCollection<IAtaChapter> SystemAtaChapters
        {
            get { return _systemAtaChapters; }
            set
            {
                _systemAtaChapters = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<IAtaChapter> CabinAtaChapters
        {
            get { return _cabinAtaChapters; }
            set
            {
                _cabinAtaChapters = value;
                OnPropertyChanged();
            }
        }
    }
}
