using System;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using VmsStationScraper.Model;

namespace VmsStationScraper
{
    internal class Program
    {
        #region Constants

        private const string CAG = @"CAG-";
        private const decimal CAG_ID = 36030;
        private const decimal CoordFactor = (decimal) 0.000001;

        #endregion

        #region Constructor

        private static void Main(string[] args)
        {
            RunAsync().Wait();
        }

        #endregion

        #region Methods

        private static async Task RunAsync()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/xml"));
            client.DefaultRequestHeaders.Add(@"User-Agent", "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/43.0.2357.134 Safari/537.36");

            var resource = @"https://www.vms.de/vms3/" +
                           @"XML_COORD_REQUEST" +
                           @"?coord=12.921834:50.831591:WGS84" +
                           @"&inclFilter=1" +
                           @"&radius_1=5000" +
                           @"&type_1=STOP" +
                           @"&coordOutputFormat=WGS84";
            var resourceUri = new Uri(resource, UriKind.Absolute);
            var response = await client.GetAsync(resourceUri);

            if(!response.IsSuccessStatusCode)
                throw new Exception();

            var content = await response.Content.ReadAsStringAsync();
            var buffer = Encoding.UTF8.GetBytes(content);

            using (var stream = new MemoryStream(buffer))
            {
                var serializer = new XmlSerializer(typeof(ItdRequest));
                var result = (ItdRequest)serializer.Deserialize(stream);
                WriteXml(result);
            }
        }

        private static void WriteXml(ItdRequest itdRequest)
        {
            using (var writer = XmlWriter.Create(@"stops.xml", new XmlWriterSettings{Indent = true}))
            {
                writer.WriteStartElement(@"stops");

                foreach (var item in itdRequest.ItdCoordInfoRequest.ItdCoordInfo.CoordInfoItemList.CoordInfoItems)
                {
                    writer.WriteStartElement(@"stop");

                    writer.WriteElementString(@"name", item.Name);

                    var idString = item.Id.ToString(CultureInfo.InvariantCulture);
                    writer.WriteElementString(@"id", idString);

                    var cvag = string.Empty;
                    if (idString.StartsWith(CAG_ID.ToString(CultureInfo.InvariantCulture)))
                    {
                        var cagIdLength = CAG_ID.ToString(CultureInfo.InvariantCulture).Length;
                        var cvagId = idString[cagIdLength].Equals('0')
                            ? idString.Substring(cagIdLength + 1)
                            : idString.Substring(cagIdLength);
                        cvag = CAG + cvagId;
                    }

                    writer.WriteElementString(@"cvag", cvag);

                    writer.WriteStartElement(@"coordinates");

                    foreach (var coords in item.ItdPathCoordinates.ItdCoordinateBaseElemList.ItdCoordinateBaseElem)
                    {
                        writer.WriteStartElement(@"set");

                        writer.WriteElementString(@"latitude", (coords.X * CoordFactor).ToString(CultureInfo.InvariantCulture));
                        writer.WriteElementString(@"longitude", (coords.Y * CoordFactor).ToString(CultureInfo.InvariantCulture));

                        writer.WriteEndElement();
                    }

                    writer.WriteEndElement();

                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
            }
        }

        #endregion
    }
}
