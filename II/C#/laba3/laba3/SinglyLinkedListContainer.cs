using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace laba3
{
    class SinglyLinkedListContainer:IContainer
    {
        class Node
        {
            public IName data;
            public Node next;
            public Node(IName p)
            {
                data = p;
            }
            public override string ToString()
            {
                return data.ToString();
            }

        }
        Node head = null;
        int count = 0;
        public int Count
        {
            get { return count; }
            protected set { if (value >= 0) count = value; }
        }
        public void Add(IName p)
        {
            Node node = new Node(p);
            if (head == null)
                head = node;
            else
            {
                node.next = head;
                head = node;
            }
            count++;
        }
        private Node GetValue(int index)
        {
            if (index < 0 || index > Count)
                throw new IndexException("Index out of range");
            Node temp = head;
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
            Node temp = GetValue(index);
            if (temp == head)
            {
                Node node = head;
                head = head.next;
                count--;
            }
            Node prevTemp = GetValue(index - 1);
            prevTemp.next = temp.next;
            count--;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (Node i = head; i != null; i = i.next)
                sb.Append(i.data.ToString()).Append(" \n");
            return sb.ToString();
        }
        private void Swap(Node first, Node second)
        {

            IName temp = first.data;
            first.data = second.data;
            second.data = temp;




        }
        public void Sort()
        {

            for (Node i = head; i.next!=null; i=i.next)
            {
               // if (i.next == null)
                   // throw new NullReferenceException("Next node is null");
                // Node temp = head;
                for (Node j = i; j.next!=null; j=j.next)
                {
                   // if (j.next == null)
                      //  throw new NullReferenceException("Next node is null");
                    if (j.data.CompareTo( j.next.data)<0)
                    {
                        Swap(j, j.next);
                    }
                   
                }

            }



        }

        public void Clear()
        {
            //if (count == 0)
            //    throw new NullReferenceException("List has not nodes");
            while (count != 0)
            {
                Node temp= head;
                head = head.next;
                count--;

            }
        }
        
        public IName this[int index]
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
        private IName FindNode(int index)
        {
            if(index<0||index>Count)
                throw new IndexException("Index out of range");
            Node temp = GetValue(index);
            return temp.data;

        }
        public IName this[string name]
        {
            get
            {
                Node temp = head;
                for (int i = 0; i < Count; i++)
                {
                    if (name == temp.data.Name)
                        return temp.data;
                    temp = temp.next;
                }
                throw new ArgumentException("Does not exist");

            }
            
        }
        //public Product this[double price]
        //{
        //    get
        //    {
        //        Node temp = head;
        //        for (int i = 0; i < Count; i++)
        //        {
        //            if (price == temp.data.Price)
        //                return temp.data;
        //            temp = temp.next;
        //        }
        //        throw new ArgumentException("Does not exist");
        //    }
            
        //}

    }
}



