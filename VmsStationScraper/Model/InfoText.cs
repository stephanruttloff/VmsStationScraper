using System.Xml.Serialization;

namespace VmsStationScraper.Model
{
    public class InfoText
    {
        [XmlElement(@"content")]
        public string Content { get; set; }

        [XmlElement(@"subtitle")]
        public string Subtitle { get; set; }
    }
}
