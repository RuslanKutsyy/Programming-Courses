using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CommandPattern.Core.Contracts;
using System.Reflection;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            var commandArr = args.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string commandName = (commandArr[0] + "Command").ToLower();
            string[] cmdArgs = commandArr.Skip(1).ToArray();

            var commandType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.Name.ToLower() == commandName);

            if (commandType == null)
            {
                throw new ArgumentException("Invalid command type!");
            }

            var instanceType = Activator.CreateInstance(commandType);          

            var result = ((ICommand)instanceType).Execute(cmdArgs);

            return result;
        }
    }
}
