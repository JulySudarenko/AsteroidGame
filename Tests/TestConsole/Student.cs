using System;
using TestConsole.Loggers;

namespace TestConsole
{
    internal class Student : ILogger
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronimyc { get; set; }

        public int GroupId { get; set; }

        public void Log(string Message)
        {
            Console.WriteLine("Студент {0} пишет в журнал: {1}", Name, Message); ;
        }
    }
}



