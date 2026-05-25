using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba3
{
    interface IContainer
    {
        IName this[int index] { get; }
        IName this[string name] { get; }
        void Add(IName p);
        void Remove(int index);
        void Sort();
        int Count { get; }

    }
}
