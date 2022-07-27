using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Globalization;
using System.Reflection;
using System.Threading.Tasks;

namespace The_Architect.Modules
{
    public class _Help : ModuleBase<SocketCommandContext>
    {
        [Command("help")]
        public async Task DefaultHelp()
        {
            EmbedBuilder help = new EmbedBuilder();

            help.WithTitle("Enter any of the following commands after 'g.'")
                .AddInlineField("factorio", "Get commands for Factorio")
                .AddInlineField("minecraft", "Still a work in progress")
                .AddInlineField("ping", "Pong!")
                .AddInlineField("invite", "Work in progress")
                .AddInlineField("zoltar", "Zoltar sees, knows, hears all. Ask him your questions.")
                .AddInlineField("42", "What do you know about 42???")
                .AddInlineField("whiterabbit", "Follow it!")
                .AddInlineField("countdown", "countdown timer. Enter number of seconds after command.")
                .WithColor(Color.Red);

            await ReplyAsync("", false, help.Build());
        }

        [Command("ping")]
        public async Task DefaultPing()
        {
            await ReplyAsync($"Hey, {Context.User.Mention}! Go Pong yourself!!");
        }

        [Command("invite"), RequireUserPermission(GuildPermission.CreateInstantInvite)]
        public async Task DefaultInvite()
        {
                     
            await ReplyAsync("Who ya tryin' ta invite, ya fool?!");
        }
    }
}
