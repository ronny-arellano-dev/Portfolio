using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Linq;

namespace The_Architect.Modules
{
    // Class for reading from files in the Text_Files folder
    public class GetLine
    {
        public string filename;
        
        public string Answer()
        {
            string _filename = filename;
            var filePath = Path.Combine(Environment.CurrentDirectory, @"Text_Files\", _filename);
            var rnd = new Random();
            StreamReader sr = new StreamReader(filePath);
            var lines = File.ReadAllLines(filePath);
            var rndLineNum = rnd.Next(0, lines.Length - 1);
            var line = lines[rndLineNum];

            return line;
        }                
     }

        
    //public class 
}
