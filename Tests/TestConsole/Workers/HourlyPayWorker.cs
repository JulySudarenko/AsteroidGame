using System;

//July Sudarenko
namespace TestConsole.Workers
{
    internal class HourlyPayWorker : Worker
    {
        public HourlyPayWorker(string Name, decimal Payment) : base(Name, Payment)
        {
        }

        //public decimal HourlyPay { get; private set; }
        //public HourlyPayWorker(string Name, decimal HourlyPay) 
        //    : base(Name)
        //{
        //    this.HourlyPay = HourlyPay;
        //}

        public override void AveragePayment()
        {
            Console.WriteLine(Math.Round(Payment * 20.80m * 8.00m));
        }
    }
}



