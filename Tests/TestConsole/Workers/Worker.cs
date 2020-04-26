
//July Sudarenko
namespace TestConsole.Workers 
{
    internal abstract class Worker
    {
        public string Name { get; private set; }
        public decimal Payment { get; private set; }

        public Worker(string Name, decimal Payment)
        {
            this.Name = Name;
            this.Payment = Payment;
        }

        public Worker()
        {
        }

        public abstract void AveragePayment();

    }

}



