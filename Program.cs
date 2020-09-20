using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace JishoBot
{
    class Program
    {
        public static Task Main(string[] args)
        {
            var container = BuildServiceProvider();
            var bot = container.GetRequiredService<Jisho>();
            return bot.InitializeAsync();
        }

        private static IServiceProvider BuildServiceProvider()
        {
            return new ServiceCollection()
                .AddSingleton<Jisho>()
                .AddSingleton(_ => new )
        }
    }
}