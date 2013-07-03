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
    public class SelectUpgradeViewModel : ViewModelBase
    {
        private string _ataChapterTitle;
        private readonly UpgradeModel _model;
        private ObservableCollection<ISubAtaChapter> _subAtaChapter;

        public ObservableCollection<ISubAtaChapter> SubAtaChapter
        {
            get { return _subAtaChapter; }
            set
            {
                _subAtaChapter = value;
                OnPropertyChanged();
            }
        } 


        public SelectUpgradeViewModel()
        {
            _model = new UpgradeModel();
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
        }
    }
}
