using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba3
{
    public class СontainerEnum<T> : IEnumerator<T> where T : IName<T>, IComparable<T>
    {
        private Container<T> container;
        int position = -1;
        internal СontainerEnum(Container<T> container)
        {
            this.container = container;
        }
        public bool MoveNext()
        {
            position++;
            return (position < container.Count);
        }
        public void Reset()
        {
            position = -1;
        }
        object IEnumerator.Current
        {
            get { return Current; }
        }
        public T Current
        {
            get { return container[position]; }
        }
        public void Dispose() { }

    }
}
