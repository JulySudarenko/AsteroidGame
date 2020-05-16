using System;
using System.Runtime.Serialization;

//July_Sudarenko
namespace TestConsole
{
    [Serializable]
    public class ComputeExceptionException : ApplicationException
    {
        public ComputeExceptionException() { }
        public ComputeExceptionException(string message) : base(message) { }
        public ComputeExceptionException(string message, Exception inner) : base(message, inner) { }

        protected ComputeExceptionException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }
}



