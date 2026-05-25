using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace laba3
{
    delegate bool Del<T>(T c);
    delegate bool Del2<T>(T a, T b);
    class Container<T> :IEnumerable<T>, IContainer<T> where T : IName<T>, IComparable<T>
    {

        private T[] p;

        public delegate void DelSum(string str, double sum);
        public event DelSum DelegateSum;
        public int Count { get { return p != null ? p.Length : 0; } protected set { } }
        public double PriceProduct { get; set; }
        public void Add(T product)
        {
            T[] newP = new T[Count + 1];
            for (int i = 0; i < Count; i++)
                newP[i] = p[i];
            newP[Count] = product;
            p = newP;

            PriceProduct += (product as Product).Price;
            if (DelegateSum != null)
                DelegateSum.Invoke($"Add {(product as Product).Price} to price", PriceProduct);
        }
        public void Add(IContainer<T> container)
        {
            for (int i = 0; i < container.Count; i++)
            {
                this.Add(container[i]);
            }
        }
        public void Remove(int index)
        {
            if (index < 0 || index > Count)
                throw new IndexException("Index out of range");
            T[] newP = new T[Count - 1];
            for (int i = 0, j = 0; i < Count; i++)
                if (i != index)
                    newP[j++] = p[i];
            p = newP;

            PriceProduct -= (this.p[index] as Product).Price;
            if (DelegateSum != null)
                DelegateSum.Invoke($"Removed {(this.p[index] as Product).Price} of price", PriceProduct);
        }

        public void Sort()
        {

            for (int i = 0; i < p.Length - 1; i++)
            {
                for (int j = 0; j < p.Length - i - 1; j++)
                {

                    if (p[j].CompareTo(p[j + 1]) > 0)
                    {
                        T temp;
                        temp = p[j];
                        p[j] = p[j + 1];
                        p[j + 1] = temp;
                    }

                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < p.Length; i++)
                sb.Append(p[i].ToString()).Append(" \n");
            return sb.ToString();
        }
        public T this[int index]
        {

            get {
                try
                {
                    return p[index];
                }
                catch (Exception e)
                {

                    throw new IndexException("Index out of range", e);
                }
            }
            set { p[index] = value; } }
        public T this[string name]
        {
            get
            {
                for (int i = 0; i < Count; i++) {
                    if (name == p[i].Name)

                        return p[i];
                }

                throw new ArgumentException("Does not exist");
            }
            set
            {
                for (int i = 0; i < Count; i++)
                {
                    ////////////////////////////////////////
                    p[i] = value;
                }
            }
        }
       
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public IEnumerator<T> GetEnumerator()
        {
             return new СontainerEnum<T>(this);
            //for (int i = 0; i >= Count; i++)
            //    yield return this[i];
        }
        public IEnumerable<T>InverseEnumerator()
        {
            for (int i = Count - 1; i >= 0; i--)
                yield return this[i];
        }
        public IEnumerable<T>SortEnumerator()
        {
            T[] temp=new T[Count];
            for(int i=0;i<Count;i++)
            {
                temp[i] = p[i];
            }
            Array.Sort<T>(temp);
            for (int i = 0; i < Count; i++)
            {
                yield return temp[i];
            }
        }
        public IEnumerable<T>StringEnumerator(string str)
        {
            for(int i=0;i<Count;i++)
            {
                if (this[i].Name.Contains(str))
                    yield return this[i];
            }
        }
        public void Sort(Del2<T> del)
        {
            
            for (int i = 0; i < p.Length - 1; i++)
            {
                for (int j = 0; j < p.Length - i - 1; j++)
                {

                    if (del(p[j], p[j + 1]))
                    {
                        T temp;
                        temp = p[j];
                        p[j] = p[j + 1];
                        p[j + 1] = temp;
                    }

                }
            }
        }
        public IEnumerable<T> FindAll(Del<T> del)
        {
            for (int i = 0; i < Count; i++)
            {
                if (del(p[i]))
                    yield return p[i];
            }
        }
        //public static void SerializationContainer<T>(Container<T> container, string str)// where T : IName<T>
        //{

        //    using (FileStream file = new FileStream(str, FileMode.Create))
        //    {
        //        using (BinaryWriter writer = new BinaryWriter(file))
        //        {
        //            foreach (var a in container)
        //            {
        //                writer.Write(a.GetType().Assembly.ToString());
        //                writer.Write(a.GetType().FullName);

        //                a.GetData(writer);

        //            }
        //        }
        //    }
        //}

    }
}
