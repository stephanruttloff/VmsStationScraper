using System.Xml.Serialization;

namespace VmsStationScraper.Model
{
    public class InfoLink
    {
        [XmlElement(@"infoLinkText")]
        public string InfoLinkText { get; set; }

        [XmlElement(@"infoText")]
        public InfoText InfoText { get; set; }
    }
}
