using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirbusCatalogue.ViewModel.Filter
{
    /// <summary>
    /// This category criteria interface helps for grouping items. It uses a type and returns a grouping criteria for building categories.
    /// It is used for grouping aircrafts to given criterias.
    /// </summary>
    /// <typeparam name="T">The type to group</typeparam>
    public interface ICategoryCriteria<in T>
    {
        string GetFilterValue(T typeToCategorize);
    }
}
