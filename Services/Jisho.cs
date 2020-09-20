using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Disqord.Bot;
using JishoBot.Services.Search;

namespace JishoBot
{
    public class Jisho
    {
        private readonly DiscordBot _jisho;
        private readonly ISearch _search;

        public Jisho(DiscordBot jisho, ISearch search)
        {
            _jisho = jisho;
            _search = search;
        }

        public async Task InitializeAsync()
        {
            _jisho.AddModules(Assembly.GetEntryAssembly());

            await _jisho.RunAsync();
        }
    }
}