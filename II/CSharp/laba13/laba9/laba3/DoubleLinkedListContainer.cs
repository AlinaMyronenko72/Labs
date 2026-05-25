using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba3
{
    internal class NodeNode<T>
    {
        public T data;
        public NodeNode<T> next;
        public NodeNode<T> prev;
        public NodeNode(T p = default)
        {
            data = p;
        }
        public override string ToString()
        {
            return data.ToString();
        }

    }
    class DoubleLinkedListContainer<T> : IEnumerable<T>, IContainer<T> where T : IName<T>
    {

        NodeNode<T> head = null;
        NodeNode<T> tail = null;
        int count = 0;
        public int Count
        {
            get { return count; }
            protected set { if (value >= 0) count = value; }
        }



        public void Add(T p)
        {
            NodeNode<T> node = new NodeNode<T>(p);
            if (head == null)
            {
                head = node;
                tail = node;
            }
            else
            {

                node.prev = tail;
                tail.next = node;
                tail = node;
            }

            count++;
        }
        public void Add(IContainer<T> container)
        {
            for (int i = 0; i < container.Count; i++)
            {
                this.Add(container[i]);
            }
        }
        private NodeNode<T> GetValue(int index)
        {
            if (index < 0 || index > Count)
                throw new IndexException("Index out of range");
            NodeNode<T> temp = head;
            for (int i = 0; i < index; i++)
            {
                temp = temp.next;
            }

            return temp;
        }
        public void Remove(int index)
        {
            if (index < 0 || index > Count)
                throw new IndexException("Index out of range");
            NodeNode<T> temp = GetValue(index);
            if (temp == head)
            {

                head = head.next;
                count--;
            }
            if (temp == tail)
            {
                tail = tail.prev;
                count--;
            }

            temp.prev.next = temp.next;
            temp.next.prev = temp.prev;

            count--;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (NodeNode<T> i = head; i != null; i = i.next)
                sb.Append(i.data.ToString()).Append(" \n");
            return sb.ToString();
        }
        private void Swap(NodeNode<T> first, NodeNode<T> second)
        {

            T temp = first.data;
            first.data = second.data;
            second.data = temp;




        }
        public void Sort()
        {
            for (NodeNode<T> i = tail; i.prev != null; i = i.prev)
            {
                // if (i.prev == null)
                //  throw new NullReferenceException("Previos node is null");

                for (NodeNode<T> j = i; j.prev != null; j = j.prev)
                {
                    // if (j.prev == null)
                    //  throw new NullReferenceException("Previos node is null");
                    if (j.data.CompareTo(j.prev.data) < 0)
                    {
                        Swap(j, j.prev);
                    }

                }

            }
        }
        public void Clear()
        {
            if (count == 0)
                throw new NullReferenceException("List has not nodes");
            while (count != 0)
            {
                NodeNode<T> temp = head;
                head = head.next;
                count--;

            }
        }
        public T this[int index]
        {
            get
            {
                try
                {
                    return FindNode(index);
                }
                catch (Exception e)
                {

                    throw new IndexException("Out of range", e);
                }
            }

        }
        private T FindNode(int index)
        {
            if (index < 0 || index > Count)
                throw new IndexException("Index out of range");
            NodeNode<T> temp = GetValue(index);
            return temp.data;

        }



        public T this[string name]
        {
            get
            {
                NodeNode<T> temp = head;
                for (int i = 0; i < Count; i++)
                {
                    if (name == temp.data.Name)
                        return temp.data;
                    temp = temp.next;
                }
                throw new ArgumentException("Does not exist");

            }

        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }
        public IEnumerator<T> GetEnumerator()
        {
            return new DoubleLinkedContainerEnum<T>(head);
        }
        public IEnumerable<T> InverseEnumerator()
        {
            for (NodeNode<T> i = tail; i != null; i = i.prev)
                yield return i.data;
        }
        //public IEnumerable<T> SortEnumerator()
        //{
        //    NodeNode<T> temp=new NodeNode<T>();
        //    NodeNode<T> newtemp = head; 
        //}
        public IEnumerable<T> StringEnumerator(string str)
        {
            for (NodeNode<T> i = head; i!= null; i = i.next)
            {
                if (i.data.Name.Contains(str))
                    yield return i.data;
            }
        }
    }
}
