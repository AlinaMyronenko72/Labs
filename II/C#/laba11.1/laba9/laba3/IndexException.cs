using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba3
{
    class IndexException:Exception
    {
        public IndexException() : base("Index out of range") { }
        public IndexException(string message) : base(message) { }
        public IndexException(string message, Exception inner) : base(message, inner) { }
    }
}
