using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Qmmands;
using Disqord;
using Disqord.Bot;
using JishoBot.Services.Search;
using JishoBot.Extensions;

namespace JishoBot.Modules
{
    public class SearchCommands : DiscordModuleBase
    {
        private readonly ISearch _search;
        public SearchCommands(ISearch search)
        {
            _search = search;
        }

        [Command("word")]
        public async Task WordSearchAsync(string word)
        {
            var response = await _search.GetResponseAsync($"https://jisho.org/api/v1/search/words?keyword={word}").ConfigureAwait(false);
            var result = JsonConvert.DeserializeObject<JObject>(response);

            await Context.Message.Channel.EmbedAsync(new LocalEmbedBuilder().WithTitle($"{result["data"][0]["japanese"][0]["word"]} ({result["data"][0]["japanese"][0]["reading"]})").WithDescription($"Test")).ConfigureAwait(false);
        }
    }
}