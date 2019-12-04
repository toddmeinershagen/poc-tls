using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tls.Engine
{
    public class TlsChecker
    {
        public static readonly HttpClient client = new HttpClient();

        public async Task<Dictionary<string, string>> GetSupportedProtocols()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("text/html"));

            var html = await client.GetStringAsync("https://www.ssllabs.com/ssltest/viewMyClient.html");
            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            var values = new Dictionary<string, string>
            {
                { "1.3", doc.DocumentNode.SelectSingleNode("//td[@id='protocol_tls1_3']").GetDirectInnerText() },
                { "1.2", doc.DocumentNode.SelectSingleNode("//td[@id='protocol_tls1_2']").GetDirectInnerText() },
                { "1.1", doc.DocumentNode.SelectSingleNode("//td[@id='protocol_tls1_1']").GetDirectInnerText() },
                { "1.0", doc.DocumentNode.SelectSingleNode("//td[@id='protocol_tls1']").GetDirectInnerText() }
            };

            return values;
        }
    }
}
