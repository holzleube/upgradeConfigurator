using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.Common.BasicData;

namespace AirbusCatalogue.ViewModel.Templates
{
    public abstract class ViewModelBase: BindableBase
    {
        public abstract void Initialize(object parameter);
    }
}
