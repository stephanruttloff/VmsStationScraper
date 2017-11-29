using System.Globalization;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace VmsStationScraper.Model
{
    [XmlRoot(@"itdRequest")]
    public class ItdRequest
    {
        [XmlAttribute(@"version")]
        public string Version { get; set; }

        [XmlElement(@"itdCoordInfoRequest")]
        public ItdCoordInfoRequest ItdCoordInfoRequest { get; set; }
    }
}
