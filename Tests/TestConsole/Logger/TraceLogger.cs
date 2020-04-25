namespace TestConsole.Loggers
{
    internal class TraceLogger : Logger
    {
        //Сборка инфы о трассировке событий. Можно указываеть куда записывать данные.
        public override void Log(string Message)
        {
            System.Diagnostics.Trace.WriteLine(Message);
        }

        public override void Flush()
        {
            System.Diagnostics.Trace.Flush();
        }
    }
}


