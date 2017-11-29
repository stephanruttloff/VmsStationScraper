using System.Xml.Serialization;

namespace VmsStationScraper.Model
{
    public class ItdPathCoordinates
    {
        [XmlElement(@"coordEllipsoid")]
        public string CoordEllipsoid { get; set; }

        [XmlElement(@"coordType")]
        public string CoordType { get; set; }

        [XmlElement(@"itdCoordinateBaseElemList")]
        public ItdCoordinateBaseElemList ItdCoordinateBaseElemList { get; set; }
    }
}
