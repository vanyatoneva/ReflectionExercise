using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] commArgs = args.Split(" ");
            string command = commArgs[0];
            string[] arguments = commArgs.Skip(1).ToArray();

            Type commandType = Assembly.
                GetEntryAssembly().
                GetTypes().
                FirstOrDefault(t => t.Name == $"{command}Command"); 

            if(commandType == null)
            {
                throw new InvalidOperationException("Command not found.");
            }

            ICommand commandInstance = Activator.CreateInstance(commandType) as ICommand;

            return commandInstance.Execute(arguments);
        }
    }
}
