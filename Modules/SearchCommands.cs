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

            var embed = new LocalEmbedBuilder()
                .WithTitle($"Jisho:")
                .WithDescription($"Word: {result["data"][0]["japanese"][0]["word"]}\n(Furigana: `{result["data"][0]["japanese"][0]["reading"]}`)")
                .AddField("JLPT Level", result["data"][0]["jlpt"][0], true);

            StringBuilder englishDefinitions = new StringBuilder();
            foreach (var entry in result["data"][0]["senses"][0]["english_definitions"])
            {
                englishDefinitions.Append($"{entry}, ");
            }

            StringBuilder speechParts = new StringBuilder();
            foreach (var entry in result["data"][0]["senses"][0]["parts_of_speech"])
            {
                speechParts.Append($"{entry}, ");
            }

            embed.AddField("English Meaning", englishDefinitions);
            embed.AddField("Part of Speech", speechParts, true);

            await Context.Message.Channel.EmbedAsync(embed).ConfigureAwait(false);
        }
    }
}