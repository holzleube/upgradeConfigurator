using AirbusCatalogue.ViewModel.ViewDataElements;


namespace AirbusCatalogue.DataModel
{
    public class ConfigurationDataItem:BasicDataItem
    {
        public ConfigurationDataItem(string uniqueId, string title, string imagePath, string description, string content, SampleDataGroup @group) : base(uniqueId, title, imagePath, description, content, @group, 20, 50)
        {
        }
    }
}
