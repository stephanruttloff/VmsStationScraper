using System.Xml.Serialization;

namespace VmsStationScraper.Model
{
    public class CoordInfoItem
    {
        [XmlAttribute(@"name")]
        public string Name { get; set; }

        [XmlAttribute(@"type")]
        public string Type { get; set; }

        [XmlAttribute(@"id")]
        public decimal Id { get; set; }

        [XmlAttribute(@"locality")]
        public string Locality { get; set; }

        [XmlAttribute(@"distance")]
        public decimal Distance { get; set; }

        [XmlAttribute(@"stateless")]
        public decimal Stateless { get; set; }

        [XmlElement(@"itdPathCoordinates")]
        public ItdPathCoordinates ItdPathCoordinates { get; set; }

        [XmlElement(@"itdIndexInfoList")]
        public ItdIndexInfoList ItdIndexInfoList { get; set; }
    }
}
