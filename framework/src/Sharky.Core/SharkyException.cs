using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Sharky.Core
{
    public class SharkyException : Exception
    {
        public SharkyException()
        {

        }

        public SharkyException(string message) : base(message)
        {

        }

        public SharkyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public SharkyException(SerializationInfo serializationInfo, StreamingContext context)
        : base(serializationInfo, context)
        {
                
        }
    }
}
