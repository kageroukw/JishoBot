using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Disqord.Bot;

namespace JishoBot
{
    public class Jisho
    {
        private readonly DiscordBot _jisho;

        public Jisho(DiscordBot jisho)
        {
            _jisho = jisho;
        }

        public async Task InitializeAsync()
        {
            _jisho.AddModules(Assembly.GetEntryAssembly());

            await _jisho.RunAsync();
        }
    }
}