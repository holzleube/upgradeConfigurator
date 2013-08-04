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
using AirbusCatalogue.Model.Config;

namespace AirbusCatalogue.ViewModel.ViewModel.Upgrades
{
    public class SelectUpgradeViewModel : ViewModelBase, IUpgradeSelectionViewModel
    {
        private string _ataChapterTitle;
        private readonly UpgradeModel _model;
        private bool _isAppBarVisible;
        private ObservableCollection<ISubAtaChapter> _subAtaChapter;
        private ObservableCollection<IUpgradeItem> _selectedUpgradeItems = new ObservableCollection<IUpgradeItem>();
        private ISubAtaChapter _currentSelectedItem ;
        private IUpgradeItem _selectedTdu;
        private ICommand _gridViewItemWasSelectedCommand;
        private ICommand _subAtaChapterWasClickedCommand;

        public SelectUpgradeViewModel()
        {
            _model = new UpgradeModel();
            SelectedUpgradeItems = new ObservableCollection<IUpgradeItem>( new ConfigurationModel().GetCurrentConfiguration().Upgrades);
            SetIsAppBarVisible();
        }

        private void SetIsAppBarVisible()
        {
            IsAppBarVisible = (SelectedUpgradeItems.Count > 0);
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

        public bool IsAppBarVisible
        {
            get { return _isAppBarVisible; }
            set 
            {
                _isAppBarVisible = value;
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

        public ISubAtaChapter CurrentSelectedItem
        {
            get { return _currentSelectedItem; }
            set 
            { 
                _currentSelectedItem = value;
                OnPropertyChanged();
                SetCorrectSelectedTdu();
            }
        }

        private void SetCorrectSelectedTdu()
        {
            foreach (var upgradeItem in CurrentSelectedItem.UpgradeItems)
            {
                if (IsItemSelected(upgradeItem))
                {
                    SelectedTdu = upgradeItem;
                    return;
                }
            }
            SelectedTdu = null;
        }

        private bool IsItemSelected(IUpgradeItem upgradeItem)
        {
            return SelectedUpgradeItems.Contains(upgradeItem);
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
            get 
            { 
                return _gridViewItemWasSelectedCommand ?? (_gridViewItemWasSelectedCommand = new RelayCommand<IUpgradeItem>(GridViewItemWasSelected)); 
            }
            
        }

        public ICommand SubAtaChapterWasClickedCommand
        {
            get 
            {
                return _subAtaChapterWasClickedCommand ?? (_subAtaChapterWasClickedCommand = new RelayCommand<ISubAtaChapter>(SubAtaChapterWasClicked)); 
            }
            
        }

        private void SubAtaChapterWasClicked(ISubAtaChapter obj)
        {
            CurrentSelectedItem = obj;
            SetCorrectSelectedTdu();
        }

        private void GridViewItemWasSelected(IUpgradeItem obj)
        {
            if(SelectedTdu == null) 
            {
                SelectedTdu = obj;
                SelectedUpgradeItems.Add(obj);
                SetIsAppBarVisible();
                return;
            }
            if (SelectedTdu.Equals(obj))
            {
                SelectedTdu = null;
                SelectedUpgradeItems.Remove(obj);
                SetIsAppBarVisible();
                return;
            }
            SelectedUpgradeItems.Remove(SelectedTdu);
            SelectedUpgradeItems.Add(obj);
            SelectedTdu = obj;
            SetIsAppBarVisible();
            
        }
        
    }
}
