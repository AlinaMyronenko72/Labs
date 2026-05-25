using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba3
{
    class DoubleLinkedContainerEnum<T> : IEnumerator<T> where T : IName<T>, IComparable<T>
    {
        NodeNode<T> position;
        NodeNode<T> reset;
        internal DoubleLinkedContainerEnum(NodeNode<T> head)
        {
            reset = new NodeNode<T>() { next = head };
            position = reset;
        }
        public bool MoveNext()
        {

            position = position.next;
            return (position!= null);
        }
        public void Reset()
        {
            position = reset;
        }
        object IEnumerator.Current
        {
            get { return Current; }
        }
        public T Current
        {
            get { return position.data; }
        }
        public void Dispose() { }
    }
    
}
