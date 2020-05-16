using System.Collections.Generic;
using System;
using System.Collections;

//July Sudarenko
namespace TestConsole.Workers
{
    internal class JoinWorker : Worker, IComparable
    {
        private List<Worker> _Workers = new List<Worker>();

        public object Current => _Workers.Count;

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



