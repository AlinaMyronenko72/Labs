using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace laba3
{
    class Serialization

    {
        public static void SerializationContainer<T>(Container<T> container, string str) where T : IName<T>
        {

            using (FileStream file = new FileStream(str, FileMode.Create))
            {
                using (BinaryWriter writer =new BinaryWriter(file))
                {
                    foreach (var a in container)
                    {
                        writer.Write(a.GetType().Assembly.ToString());
                        writer.Write(a.GetType().FullName);

                        a.GetData(writer);

                    }
                }
            }
        }
        public static void DeserializationContainer<T>(Container<T> container, string str) where T : IName<T>
        {

            using (FileStream file = new FileStream(str, FileMode.Open))
            {
                using (BinaryReader reader = new BinaryReader(file))
                {
                    while (reader.PeekChar() != -1)
                    {
                        string AssemblyName = reader.ReadString();
                        string Name = reader.ReadString();
                        Type newT = Assembly.Load(AssemblyName).GetType(Name);

                        T data = (T)Activator.CreateInstance(newT, null);
                        data.SetData(reader);
                        container.Add(data);

                    }
                }
            }
        }
    }
}
