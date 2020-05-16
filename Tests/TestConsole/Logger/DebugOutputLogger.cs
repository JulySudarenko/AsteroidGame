namespace TestConsole.Loggers
{
    internal class DebugOutputLogger : Logger
    {
        public override void Log(string Message)
        {
            System.Diagnostics.Debug.WriteLine(Message);
        }
    }
}


