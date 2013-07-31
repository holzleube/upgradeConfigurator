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
using AirbusCatalogue.ViewModel.ViewInterfaces;
using AirbusCatalogue.ViewModel.ViewInterfaces.Aircraft;
using GalaSoft.MvvmLight.Ioc;

namespace AirbusCatalogue.ViewModel.ViewModel.Upgrades
{
    public class SelectUpgradeViewModel : ViewModelBase, IUpgradeSelectionViewModel
    {
        private string _ataChapterTitle;
        private readonly UpgradeModel _model;
        private ObservableCollection<ISubAtaChapter> _subAtaChapter;
        private ObservableCollection<IUpgradeItem> _selectedUpgradeItems = new ObservableCollection<IUpgradeItem>();
        private ISubAtaChapter _currentSelectedItem ;
        private IUpgradeItem _selectedTdu;
        private ICommand _gridViewItemWasSelectedCommand;

        public SelectUpgradeViewModel()
        {
            _model = new UpgradeModel();
        }

        public ObservableCollection<ISubAtaChapter> SubAtaChapter
        {
            get { return _subAtaChapter; }
            set
            {
                _subAtaChapter = value;
                OnPropertyChanged();
            }
        } 

        public string AtaChapterTitle
        {
            get { return _ataChapterTitle; }
            set 
            { 
                _ataChapterTitle = value;
                OnPropertyChanged();
            }
        }
        public override void Initialize(object parameter)
        {
            var ataChapterId = parameter as string;
            if (ataChapterId == null)
            {
                return;
            }
            AtaChapterTitle = ataChapterId;
            SubAtaChapter = new ObservableCollection<ISubAtaChapter>(_model.GetAtaChapterById(ataChapterId).SubAtaChapters);
            CurrentSelectedItem = SubAtaChapter[0];
        }

        public ICommand UpgradeItemSelectedCommand
        {
            get
            {
                return new RelayCommand(UpgradesWereSelectedCommand);
            }
        }

        private void UpgradesWereSelectedCommand()
        {
            _model.SelectUpgradeItem(SelectedUpgradeItems.ToList());
            var classToNavigate = SimpleIoc.Default.GetInstance<ISummary>();
            NavigateToClass(classToNavigate);
        }

        private void NavigateToClass(object classToNavigate)
        {
            var navigationService = SimpleIoc.Default.GetInstance<INavigationService>();
            navigationService.Navigate(classToNavigate.GetType());
        }

        public ObservableCollection<IUpgradeItem> SelectedUpgradeItems
        {
            get
            {
                return _selectedUpgradeItems;
            }
            set 
            { 
                _selectedUpgradeItems = value;
                OnPropertyChanged();
            }
        }

        public void UpdateSelection(IUpgradeItem itemToUpdate, bool isSelected)
        {
            if (SelectedUpgradeItems.Contains(itemToUpdate) && !isSelected)
            {
                SelectedUpgradeItems.Remove(itemToUpdate);
                return;
            }
            if (!isSelected)
            {
                return;
            }
            foreach (var upgradeItem in CurrentSelectedItem.UpgradeItems.
                Where(upgradeItem => SelectedUpgradeItems.Contains(upgradeItem)))
            {
                SelectedUpgradeItems.Remove(upgradeItem);
            }
            SelectedUpgradeItems.Add(itemToUpdate);
        }

        public ISubAtaChapter CurrentSelectedItem
        {
            get { return _currentSelectedItem; }
            set 
            { 
                _currentSelectedItem = value;
                OnPropertyChanged();
            }
        }

        public IUpgradeItem SelectedTdu
        {
            get { return _selectedTdu; }
            set 
            {
                _selectedTdu = value;
                OnPropertyChanged();
            }
        }

        public ICommand GridViewItemWasSelectedCommand
        {
            get { return _gridViewItemWasSelectedCommand ?? (_gridViewItemWasSelectedCommand = new RelayCommand<IUpgradeItem>(GridViewItemWasSelected)); }
            set
            {
                _gridViewItemWasSelectedCommand = value;
                OnPropertyChanged();
            }
        }

        private void GridViewItemWasSelected(IUpgradeItem obj)
        {
           
        }
        
    }
}
