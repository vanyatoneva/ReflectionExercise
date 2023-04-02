using CommandPattern.Core.Contracts;
using CommandPattern.IO;
using CommandPattern.IO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Core
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;
        private readonly IWriter writer;
        private readonly IReader reader;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
            writer = new ConsoleWriter();
            reader = new ConsoleReader();
        }

        public void Run()
        {
            string args = reader.ReadLine();
            try
            {
                writer.WriteLine(commandInterpreter.Read(args));
            }
            catch(InvalidOperationException ex)
            {
                writer.WriteLine(ex.Message);   
            }
        }
    }
}
