using System.Runtime.Serialization;

namespace AirbusCatalogue.Common.DataObjects.General
{
    public interface IIdentable
    {
        string UniqueId { get; set; }
    }
}
