using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity.Extensions;
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
            await ctx.Channel.SendMessageAsync("Hello World!");
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

        [Command("poll")]
        public async Task PollCommand(CommandContext ctx, int TimeLimit, string Option1, string Option2, string Option3, string Option4, params string[] Question)
        {
            var interactivity = ctx.Client.GetInteractivity();
            TimeSpan timer = TimeSpan.FromSeconds(TimeLimit);
            DiscordEmoji[] optionEmojis = { DiscordEmoji.FromName(ctx.Client, ":one:", false),
                                            DiscordEmoji.FromName(ctx.Client, ":two:", false),
                                            DiscordEmoji.FromName(ctx.Client, ":three:", false),
                                            DiscordEmoji.FromName(ctx.Client, ":four:", false),};

            string optionsString = optionEmojis[0] + " | " + Option1 + "\n\n" +
                                   optionEmojis[1] + " | " + Option2 + "\n\n" +
                                   optionEmojis[2] + " | " + Option3 + "\n\n" +
                                   optionEmojis[3] + " | " + Option4;

            var pollMessage = new DiscordMessageBuilder()
                            .AddEmbed(new DiscordEmbedBuilder()
                            .WithColor(DiscordColor.Azure)
                            .WithTitle(string.Join(" ", Question))
                            .WithDescription(optionsString));

           var putReactOn = await ctx.Channel.SendMessageAsync(pollMessage);

            foreach (var emoji in optionEmojis)
            {
                await putReactOn.CreateReactionAsync(emoji);
            }

            var result = await interactivity.CollectReactionsAsync(putReactOn, timer);

            int count1 = 0; 
            int count2 = 0;
            int count3 = 0;
            int count4 = 0;

            foreach (var emoji in result)
            {
                if (emoji.Emoji == optionEmojis[0])
                {
                    count1++;
                }
                if (emoji.Emoji == optionEmojis[1])
                {
                    count2++;
                }
                if (emoji.Emoji == optionEmojis[2])
                {
                    count3++;
                }
                if (emoji.Emoji == optionEmojis[3])
                {
                    count4++;
                }
            }
            int totalVotes = count1 + count2 + count3 + count4;
            string resultsString = optionEmojis[0] + ": " + count1 + " Votes \n" +
                                   optionEmojis[1] + ": " + count2 + " Votes \n" +
                                   optionEmojis[2] + ": " + count3 + " Votes \n" +
                                   optionEmojis[3] + ": " + count4 + " Votes \n\n" +
                                   "Общее количество проголосовавших: " + totalVotes; 

            var resultMessage = new DiscordMessageBuilder()
                .AddEmbed(new DiscordEmbedBuilder()

                .WithColor(DiscordColor.Green)
                .WithTitle("Результат голосания")
                .WithDescription(resultsString)
                );

            await ctx.Channel.SendMessageAsync(resultMessage);
        }

    }
}
