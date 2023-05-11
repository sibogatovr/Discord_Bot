using Discord.WebSocket;
using Microsoft.Extensions.Logging;

namespace Discord_Bot
{
    class Program
    {
        static void Main()
        {
            var bot = new Bot();
            bot.RunAsync().GetAwaiter().GetResult();   
        }
    }
}