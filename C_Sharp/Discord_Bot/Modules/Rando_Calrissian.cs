using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Linq;

namespace The_Architect.Modules
{
    public class Rando_Calrissian : ModuleBase<SocketCommandContext>
    {
        [Command("zoltar")]
        public async Task EightBall([Remainder] string _question) // Need the Remainder attribute to get more than one word
        {
            // Initialize output variable
            string output = "";

            // convert input to lower case
            string question = _question.ToLower();

            // decide what type of question to answer
            if (question.StartsWith("how"))
            {
                GetLine answer = new GetLine();
                answer.filename = "zoltar_how.txt";
                output = answer.Answer();
            }

            else if (question.StartsWith("when"))
            {
                GetLine answer = new GetLine();
                answer.filename = "zoltar_when.txt";
                output = answer.Answer();
            }

            else if (question.StartsWith("why"))
            {
                GetLine answer = new GetLine();
                answer.filename = "zoltar_why.txt";
                output = answer.Answer();
            }

            else if (question.StartsWith("where"))
            {
                GetLine answer = new GetLine();
                answer.filename = "zoltar_where.txt";
                output = answer.Answer();
            }

            else if (question.StartsWith("what"))
            {
                GetLine answer = new GetLine();
                answer.filename = "zoltar_what.txt";
                output = answer.Answer();
            }

            else if (question.StartsWith("will"))
            {
                GetLine answer = new GetLine();
                answer.filename = "zoltar_will.txt";
                output = answer.Answer();
            }

            else
            {
                GetLine answer = new GetLine();
                answer.filename = "zoltar_general.txt";
                output = answer.Answer();
            }

            // create embed and include question and answer
            EmbedBuilder zoltar = new EmbedBuilder();
            zoltar.WithTitle("**ZOLTAR**")
                .WithThumbnailUrl("https://zoltar.org/wp-content/uploads/2018/03/Nostalgic1.jpg")
                .AddField("You asked", _question)
                .AddField("Zoltar Says", output)
                .WithColor(Color.DarkRed);
            
            // display embed
            await ReplyAsync("",false,zoltar.Build());
        }

        [Command("roastme")]
        public async Task RoastMe()
        {
            string roast;
            GetLine answer = new GetLine();
            answer.filename = "roastme.txt";
            roast = answer.Answer();
            await ReplyAsync($"{Context.User.Mention}, {roast}");
        }

        [Command("whiterabbit")]
        public async Task WhiteRabbit()
        {
            await ReplyAsync($"Wake up, {Context.User.Mention}. \n");
            Thread.Sleep(1000);
            await ReplyAsync("...");
            Thread.Sleep(1000);
            await ReplyAsync("The Matrix has you...");
        }

        [Command("42")]
        public async Task FortyTwo()
        {
            Random _rndNum = new Random();
            int rndNum = _rndNum.Next(0, 3);

            EmbedBuilder deepThought = new EmbedBuilder();
            deepThought.WithTitle("DEEP THOUGHT")
                .WithThumbnailUrl("https://img00.deviantart.net/cfa4/i/2013/023/d/c/deep_thought_42_by_txtcla55-d5sfigx.png")
                .WithDescription("Deep Thought has deduced that it is the Answer to the Ultimate Question of Life, The Universe, and Everything Else. " +
                "But What **IS** the Ultimate Question???");
            if (rndNum == 0)
            {
               deepThought.WithColor(Color.Red);
            }
            else if (rndNum == 1)
            {
                deepThought.WithColor(Color.Blue);
            }
            else if (rndNum == 2)
            {
                deepThought.WithColor(Color.Green);
            }

            await ReplyAsync("", false, deepThought.Build());
        }

        [Command("ladyinred")]
        public async Task RedDress()
        {
            await ReplyAsync("The Woman in the Red Dress");
            // maybe include an ASCII form of the lady in red.
        }

        [Command("countdown")]
        public async Task CountDown(int seconds,[Remainder] string _name = "empty")
        {
            if(_name != "empty")
            {
                await ReplyAsync($"Countdown started for {_name}");
            }
            
            if (seconds < 300)
            {
                await ReplyAsync($"Countdown from {seconds} seconds is started and will go in 5's until it is less than 5.");
                for (int i = 0; i < seconds; i++)
                {
                    Thread.Sleep(1000);
                    int timeLeft = seconds - i;
                    if (timeLeft % 5 == 0)
                    {
                        await ReplyAsync(timeLeft.ToString());
                    }
                    else if (timeLeft < 5)
                    {
                        await ReplyAsync(timeLeft.ToString());
                    }                    
                }

                if (_name == "empty")
                {
                    await ReplyAsync("Time's Up!");
                }
                else
                {
                    await ReplyAsync($"Time's Up, {_name}!");
                }

            }
            else
            {
                await ReplyAsync("Countdown limit is 300s!");
            }
        }
    }
}
