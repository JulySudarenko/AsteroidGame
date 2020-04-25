using TestConsole.Worker;

namespace TestConsole.Worker
{
    internal class FixPayWorker : Worker
    {
        public FixPayWorker(string Name, decimal Payment) : base(Name, Payment)
        {
        }

        public override decimal AveragePayment(decimal Payment)
        {
            return Payment;
        }
    }
}



