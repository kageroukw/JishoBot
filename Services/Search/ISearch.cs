using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JishoBot.Services.Search
{
    public interface ISearch
    {
        Task<Stream> GetResponseStream(string stream);

        Task<string> GetResponseAsync(string p);

        Task<string> GetResponseAsync(string p, WebHeaderCollection headers);
    }
}