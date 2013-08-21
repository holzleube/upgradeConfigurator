using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirbusCatalogue.Common.BasicData;

namespace AirbusCatalogue.ViewModel.Templates
{
    /// <summary>
    /// This viewModel base class is important for passing paramters when you are
    /// navigating. This interface is used in View for checking a given ViewModel and 
    /// pass the navigation Parameter to the viewModel.
    /// </summary>
    public abstract class ViewModelBase: BindableBase
    {
        public abstract void Initialize(object parameter);
    }
}
