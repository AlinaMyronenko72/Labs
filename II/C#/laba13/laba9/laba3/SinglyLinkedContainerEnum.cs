using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba3
{
    public class SinglyLinkedContainerEnum<T> : IEnumerator<T> where T : IName<T>, IComparable<T>
    {
        Node<T> position;
        Node<T> reset;
        internal SinglyLinkedContainerEnum(Node<T> head)
        {
            reset = new Node<T>() { next = head };
            position = reset;
        }
        public bool MoveNext()
        {

            position = position.next;
            return (position != null);
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
