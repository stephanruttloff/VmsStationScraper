using System.Collections.Generic;
using System.Xml.Serialization;

namespace VmsStationScraper.Model
{
    public class ItdIndexInfoList
    {
        [XmlElement(@"infoLink")]
        public List<InfoLink> InfoLinks { get; set; }
    }
}
