using System;

namespace CompanyTree.Models
{
    /// <summary>
    /// This class helps us to get more detaliazed exceptions.
    /// </summary>
    public class TreeOperationException : Exception
    {
        public TreeOperationException()
        {
        }

        public TreeOperationException(string message)
        : base(message)
        {
        }

        public TreeOperationException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }


}
