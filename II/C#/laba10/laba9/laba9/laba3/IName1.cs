using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba3
{
    public interface IName<T>:IComparable<T>
    {
        string Name { get; }

    }
}
