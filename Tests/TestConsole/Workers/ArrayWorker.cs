using System;
using System.Collections;

//July Sudarenko
namespace TestConsole.Workers
{
    internal class ArrayWorker : Worker
    {
        private Worker[] _ArrayWorker;
        private static int position = -1;

        public ArrayWorker(int n)
        {
            _ArrayWorker = new Worker[n];
        }
        
        public ArrayWorker()
        {
        }
        
        public int Length => _ArrayWorker.Length;

        public Worker this[int i] => _ArrayWorker[i];
        
        public void Set(int i, Worker w)
        {
            _ArrayWorker[i].Name = w.Name;
            _ArrayWorker[i].Payment = w.Payment;
        }

        public override void AveragePayment()
        {
            foreach (var w in _ArrayWorker)
            {
                Console.Write($"{w.Name}, {w.Payment}, ");
                w.AveragePayment();
            }
        }

        public static void Print(Worker[] workers)
        {
            foreach (var w in workers)
                Console.WriteLine(w.Name, w.Payment);
        }
    }
}



