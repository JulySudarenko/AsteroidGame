namespace TestConsole.Worker
{
    internal class HourlyPayWorker : Worker
    {
        public HourlyPayWorker(string Name, decimal Payment) : base(Name, Payment)
        {
        }

        public override decimal AveragePayment(decimal Payment)
        {
            return Payment * 20.80m * 8.00m;
        }
    }
}



