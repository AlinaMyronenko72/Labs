using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba3
{
    class WriteToFile
    {
        public static void Write<T>(Container<T> container, string str) where T : IName<T>
        {
            using (StreamWriter result = new StreamWriter(str, false, System.Text.Encoding.Default))
            {
                //for (int i = 0; i < container.Count; i++)
                //{
                //    result.WriteLine($"{container[i]}");
                //}
                foreach (var v in container)
                    result.WriteLine(v);
                    result.Close();

            }
        }    
    }
}
