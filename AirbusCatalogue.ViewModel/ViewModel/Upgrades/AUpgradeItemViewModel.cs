using AirbusCatalogue.Common.DataObjects.Upgrades;
using AirbusCatalogue.Model.Upgrades;
using AirbusCatalogue.ViewModel.Command;
using AirbusCatalogue.ViewModel.Navigation;
using AirbusCatalogue.ViewModel.Templates;
using AirbusCatalogue.ViewModel.ViewInterfaces;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AirbusCatalogue.ViewModel.ViewModel.Upgrades
{
    /// <summary>
    /// This abstract class is a super type for all viewModels which holds commands for selecting upgrade items
    /// also it navigates back to summarypage if a upgrade was selected.
    /// </summary>
    public abstract class AUpgradeItemViewModel : GridHolderViewModel
    {
        protected UpgradeModel _model;
        private ObservableCollection<IUpgradeItem> _selectedUpgradeItems = new ObservableCollection<IUpgradeItem>();
        private IUpgradeItem _selectedTdu;
        private bool _isAppBarVisible;
        private ICommand _gridViewItemWasSelectedCommand;

        public AUpgradeItemViewModel()
        {
            _model = new UpgradeModel();
        }

        public ICommand GridViewItemWasSelectedCommand
        {
            get
            {
                return _gridViewItemWasSelectedCommand ?? (_gridViewItemWasSelectedCommand = new RelayCommand<IUpgradeItem>(GridViewItemWasSelected));
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

        private void GridViewItemWasSelected(IUpgradeItem obj)
        {
            if (SelectedTdu == null)
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

        protected void SetIsAppBarVisible()
        {
            IsAppBarVisible = (SelectedUpgradeItems.Count > 0);
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

        public IUpgradeItem SelectedTdu
        {
            get { return _selectedTdu; }
            set
            {
                _selectedTdu = value;
                OnPropertyChanged();
            }
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

        
    }
}
