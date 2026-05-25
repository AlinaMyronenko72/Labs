using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba3
{
    class Container:IContainer
    {
        private IName[] p;
        public int Count { get { return p != null ? p.Length : 0; } protected set { } }
        public void Add(IName product)
        {
            IName[] newP = new IName[Count + 1];
            for (int i = 0; i < Count; i++)
                newP[i] = p[i];
            newP[Count] = product;
            p = newP;
        }
        public void Remove(int index)
        {
            if (index < 0 || index > Count)
                throw new IndexException("Index out of range");
            IName[] newP = new IName[Count - 1];
            for (int i = 0, j = 0; i < Count; i++)
                if (i != index)
                    newP[j++] = p[i];
            p = newP;
        }

        public void Sort()
        {

            for (int i = 0; i < p.Length - 1; i++)
            {
                for (int j = 0; j < p.Length - i - 1; j++)
                {
                    
                    if (p[j].CompareTo(p[j + 1])>0)
                    {
                        IName temp;
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
        public IName this[int index]
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
            set {  p[index] = value; }  }
        public IName this[string name]
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
        //public IName this[double price]
        //{
        //    get
        //    {
        //        for (int i = 0; i < Count; i++)
        //        {
        //            if (price == p[i].Price)
        //                return p[i];
        //        }
        //        throw new ArgumentException("Does not exist");
        //    }
        //}

    }
}
