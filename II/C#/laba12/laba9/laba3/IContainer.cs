using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba3
{
    interface IContainer<T>
    {
        T this[int index] { get; }
        T this[string name] { get; }
        void Add(T p);
        void Remove(int index);
        void Sort();
        int Count { get; }

    }
    
    
}
