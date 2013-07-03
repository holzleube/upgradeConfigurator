using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.ViewModel.Templates;

namespace AirbusCatalogue.ViewModel.ViewModel.Upgrades
{
    public class SelectUpgradeViewModel : ViewModelBase
    {
        private string _ataChapterTitle;
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
            AtaChapterTitle = parameter as string;
        }
    }
}
