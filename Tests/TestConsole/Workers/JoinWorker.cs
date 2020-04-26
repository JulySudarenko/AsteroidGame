using System.Collections.Generic;
using System;
using System.Collections;

//July Sudarenko
namespace TestConsole.Workers
{
    internal class JoinWorker : Worker, IComparable, IEnumerator
    {
        private readonly List<Worker> _Workers = new List<Worker>();

        public object Current => throw new NotImplementedException();

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

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
            //JoinWorker _Workers = obj as JoinWorker;
            //foreach (var i in _Workers)
            //    return String.Compare();
        }

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}



