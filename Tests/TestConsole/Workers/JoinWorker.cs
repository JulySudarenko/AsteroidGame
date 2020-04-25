using System.Collections.Generic;
using System;

namespace TestConsole.Workers
{
    internal class JoinWorker : Worker
    {
        private readonly List<Worker> _Workers = new List<Worker>();

        public JoinWorker(string Name, decimal Payment) : base(Name, Payment)
        {
        }
        public JoinWorker()
        {
        }


        public void Add(Worker worker)
        {
            _Workers.Add(worker);
        }

        public override void AveragePayment()
        {
            foreach (var w in _Workers)
            {
                Console.Write($"{w.Name}, {w.Payment}, ");
                w.AveragePayment();
            }

        }
    }


}



