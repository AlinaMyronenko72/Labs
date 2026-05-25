using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba3
{
   public interface ISerialization: IComparable
    {
       // void SerializationContainer(Product product, string str);
        void GetData(BinaryWriter writer);
        void SetData(BinaryReader reader);
    }
}
