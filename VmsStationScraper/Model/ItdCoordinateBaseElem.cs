using System.Xml.Serialization;

namespace VmsStationScraper.Model
{
    public class ItdCoordinateBaseElem
    {
        [XmlElement(@"x")]
        public decimal X { get; set; }

        [XmlElement(@"y")]
        public decimal Y { get; set; }
    }
}
