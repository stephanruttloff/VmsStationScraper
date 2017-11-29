using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace VmsStationScraper.Model
{
    public class ItdCoordInfoRequest
    {
        [XmlAttribute(@"requestID")]
        public decimal RequestId { get; set; }

        [XmlElement(@"itdCoordInfo")]
        public ItdCoordInfo ItdCoordInfo { get; set; }
    }
}
