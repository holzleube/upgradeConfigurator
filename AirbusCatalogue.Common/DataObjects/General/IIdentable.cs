using System.Runtime.Serialization;

namespace AirbusCatalogue.Common.DataObjects.General
{
    public interface IIdentable
    {
        [DataMember]
        string UniqueId { get; set; }
    }
}
