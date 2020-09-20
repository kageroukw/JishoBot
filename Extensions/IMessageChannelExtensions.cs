using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Disqord;
using Disqord.Rest;

namespace JishoBot.Extensions
{
    public static class IMessageChannelExtensions
    {
        /// <summary>
        /// Sends an <paramref name="embed"/> to a <paramref name="channel"/>, with an optional <paramref name="msg"/>.
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="embed"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static Task<RestUserMessage> EmbedAsync(this IMessageChannel channel, LocalEmbedBuilder embed, string msg = "")
            => channel.SendMessageAsync(msg, embed: embed.WithColor(Color.Green).Build());
    }
}