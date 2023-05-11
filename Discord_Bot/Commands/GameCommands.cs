using Discord_Bot.External_Classes;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;

namespace Discord_Bot.Commands
{
    public class GameCommands : BaseCommandModule
    {
        [Command("cardgame")]
        public async Task SimpleCardGame(CommandContext ctx)
        {
            var UserCard = new CardBuilder();
            var BotCard = new CardBuilder();

            var userCardMessage = new DiscordMessageBuilder()
                .AddEmbed(new DiscordEmbedBuilder()

                .WithColor(DiscordColor.Azure)
                .WithTitle("Your Card")
                .WithDescription("You drew a: "+ UserCard.SelectedCard)
                );
            
            await ctx.Channel.SendMessageAsync(userCardMessage);

            var botCardMessage = new DiscordMessageBuilder()
                .AddEmbed(new DiscordEmbedBuilder()
                .WithColor(DiscordColor.Aquamarine)
                .WithTitle("Bot Card")
                .WithDescription("Bot drew a: " + BotCard.SelectedCard)
                );

            await ctx.Channel.SendMessageAsync(botCardMessage);

            if (UserCard.SelectedNumber > BotCard.SelectedNumber) 
            {
                //User Wins
                var winningMessage = new DiscordEmbedBuilder()
                {
                    Title = "##### YOU WIN the game! ####",
                    Color = DiscordColor.Green
                };

                await ctx.Channel.SendMessageAsync(embed: winningMessage);
            }
            else
            {
                //Bot wins
                var loosingMessage = new DiscordEmbedBuilder()
                {
                    Title = "###### You lost the game :'( #####",
                    Color = DiscordColor.Red
                };

                await ctx.Channel.SendMessageAsync(embed: loosingMessage);
            }
        }
    }
}
