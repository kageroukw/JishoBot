using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JishoBot.Services.Search
{
    public class Search : ISearch
    {
        public async Task<Stream> GetResponseStream(string stream)
        {
            var webRequest = (HttpWebRequest)WebRequest.Create(stream);

            try
            {
                return (await (webRequest).GetResponseAsync()).GetResponseStream();
            }
            catch (Exception ex) { Console.WriteLine(ex); return null; }
        }

        public async Task<string> GetResponseAsync(string p)
            => await new StreamReader((await ((HttpWebRequest)WebRequest.Create(p)).GetResponseAsync()).GetResponseStream()).ReadToEndAsync().ConfigureAwait(false);

        public async Task<string> GetResponseAsync(string p, WebHeaderCollection headers)
        {
            var webRequest = (HttpWebRequest)WebRequest.Create(p);
            webRequest.Headers = headers;
            return await new StreamReader((await webRequest.GetResponseAsync()).GetResponseStream()).ReadToEndAsync().ConfigureAwait(false);
        }
    }
}