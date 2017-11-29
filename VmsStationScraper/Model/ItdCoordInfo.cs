using System.Xml.Serialization;

namespace VmsStationScraper.Model
{
    public class ItdCoordInfo
    {
        [XmlElement(@"coordInfoItemList")]
        public CoordInfoItemList CoordInfoItemList { get; set; }
    }
}
