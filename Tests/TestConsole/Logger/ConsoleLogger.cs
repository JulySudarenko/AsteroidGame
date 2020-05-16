using System;

namespace TestConsole.Loggers
{
    internal class ConsoleLogger : Logger
    {
        public override void Log(string Message)
        {
            Console.WriteLine(Message);
        }
    }
}


