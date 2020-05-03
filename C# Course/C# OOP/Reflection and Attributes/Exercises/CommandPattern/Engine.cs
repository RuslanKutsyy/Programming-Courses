using System;
using System.Collections.Generic;
using System.Text;
using CommandPattern.Core.Contracts;
using System.Linq;

namespace CommandPattern
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            while (true)
            {
                string data = Console.ReadLine();

                string result = this.commandInterpreter.Read(data);

                Console.WriteLine(result);
            }
        }
    }
}
