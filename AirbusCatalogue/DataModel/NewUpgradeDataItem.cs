using AirbusCatalogue.ViewModel.ViewDataElements;


namespace AirbusCatalogue.DataModel
{
    public class NewUpgradeDataItem: BasicDataItem
    {
        public NewUpgradeDataItem(string uniqueId, string title,string imagePath, string description, string content, SampleDataGroup @group, Size size, int colSpan, int rowSpan) : base(uniqueId, title, imagePath, description, content, @group, rowSpan, colSpan)
        {
            this.TileSize = size;
        }

        public Size TileSize { get; set; }
    }

    public enum Size
    {
        Big,

        Middle,

        Small
    }
}
