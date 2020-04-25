using System;

namespace TestConsole.Workers
{
    internal class FixPayWorker : Worker
    {
        public FixPayWorker(string Name, decimal Payment) : base(Name, Payment)
        {
        }

        //public decimal FixPay { get; internal set; }

        //public FixPayWorker(string Name, decimal FixPay)
        //    : base(Name)
        //{
        //    this.FixPay = FixPay;
        //}

        public override void AveragePayment()
        {
            Console.WriteLine(Math.Round(Payment));
        }
    }
}



