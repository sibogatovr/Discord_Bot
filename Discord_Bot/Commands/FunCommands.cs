using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discord_Bot.Commands
{
    public class FunCommands : BaseCommandModule
    {
        [Command("message")]
        public async Task TestCommand(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("Hello World");
        }

        [Command("embedmessage")]
        public async Task SendEmbedMessage(CommandContext ctx)
        {
            var embedMessage = new DiscordEmbedBuilder()
            {
                Title = "This is Title",
                Description = "Description",
                Color = DiscordColor.Azure
            };

            await ctx.Channel.SendMessageAsync(embed: embedMessage);
        }

        
    }
}
