

namespace TestConsole.Worker
{
    internal abstract class Worker
    {
        private string _Name { get; set; }
        private decimal _Payment { get; set; }

        public Worker(string Name, decimal Payment)
        {
            _Name = Name;
            _Payment = Payment;
        }

        public abstract decimal AveragePayment(decimal Payment);

    }
}



