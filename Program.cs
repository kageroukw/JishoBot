using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Disqord.Bot.Prefixes;
using Disqord;
using Disqord.Bot.Extended;
using Disqord.Bot;
using JishoBot.Services;
using JishoBot.Services.Search;

namespace JishoBot
{
    public class Program
    {
        public static ISearch Search { get; private set; }

        public static Task Main(string[] args)
        {
            var container = BuildServiceProvider();
            var bot = container.GetRequiredService<Jisho>();
            return bot.InitializeAsync();
        }

        private static IServiceProvider BuildServiceProvider()
        {
            var _creds = new CredentialSetup();
            return new ServiceCollection()
                .AddSingleton<Jisho>()
                .AddSingleton<ISearch>(_ => new Search())
                .AddSingleton(_ => new DefaultPrefixProvider().AddPrefix(_creds.Prefix).AddMentionPrefix())
                .AddSingleton(container => new DiscordBotConfiguration
                {
                    Logger = new ExtendedSimpleLogger(new ExtendedSimpleLoggerConfiguration
                    {
                        EnableInformationLogSeverity = true,
                        EnableDebugLogSeverity = false,
                        EnableTraceLogSeverity = false,
                        EnableCriticalLogSeverity = false,
                        EnableErrorLogSeverity = true,
                        EnableWarningLogSeverity = true
                    }),

                    ProviderFactory = _ => container
                })
                .AddSingleton(container => new DiscordBot(TokenType.Bot, _creds.Token,
                    container.GetRequiredService<DefaultPrefixProvider>(),
                    container.GetRequiredService<DiscordBotConfiguration>()))
                .BuildServiceProvider();
        }
    }
}