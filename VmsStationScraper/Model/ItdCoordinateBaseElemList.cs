using System.Collections.Generic;
using System.Xml.Serialization;

namespace VmsStationScraper.Model
{
    public class ItdCoordinateBaseElemList
    {
        [XmlElement(@"itdCoordinateBaseElem")]
        public List<ItdCoordinateBaseElem> ItdCoordinateBaseElem { get; set; }
    }
}
