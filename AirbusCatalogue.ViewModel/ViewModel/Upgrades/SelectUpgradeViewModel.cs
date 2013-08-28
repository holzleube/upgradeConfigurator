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
    public class SelectUpgradeViewModel : AUpgradeItemViewModel, IUpgradeSelectionViewModel
    {
        private string _ataChapterTitle;


        private ObservableCollection<ISubAtaChapter> _subAtaChapter;
        private ISubAtaChapter _currentSelectedItem ;
        private ICommand _subAtaChapterWasClickedCommand;

        public SelectUpgradeViewModel():base()
        {
            SelectedUpgradeItems = new ObservableCollection<IUpgradeItem>( new ConfigurationModel().GetCurrentConfiguration().Upgrades);
            SetIsAppBarVisible();
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
        /// <summary>
        /// This method expects a type of IAtaChapter for showing the result
        /// </summary>
        /// <param name="parameter"></param>
        public override void Initialize(object parameter)
        {
            var ataChapter = parameter as IAtaChapter;
            var ataChapterId = "communication";
            if (ataChapter == null)
            {
                AtaChapterTitle = parameter as string;
            }
            else
            {
                AtaChapterTitle = ataChapter.AtaChapterNumber + " "+ ataChapter.Name;
                ataChapterId = ataChapter.UniqueId;
            }
            SubAtaChapter = new ObservableCollection<ISubAtaChapter>(_model.GetAtaChapterById(ataChapterId).SubAtaChapters);
            CurrentSelectedItem = SubAtaChapter[0];
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

        
        
    }
}
