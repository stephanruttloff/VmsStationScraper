using System.Collections.Generic;
using System.Xml.Serialization;

namespace VmsStationScraper.Model
{
    public class CoordInfoItemList
    {
        [XmlElement(@"coordInfoItem")]
        public List<CoordInfoItem> CoordInfoItems { get; set; }
    }
}
