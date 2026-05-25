using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba3
{
    class NegativeException : Exception
    {
        public NegativeException() : base("Negative value") { }
        public NegativeException(string message) : base(message) { }
        public NegativeException(string message, Exception inner) : base(message, inner) { }
    }
}
