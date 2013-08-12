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

        public IAtaChapter SelectedAtaChapter { get; set; }

       
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

        }
    }
}
