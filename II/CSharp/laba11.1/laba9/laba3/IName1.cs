using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba3
{
    public interface IName<T>:IComparable<T>
    {
        string Name { get; }
        void GetData(BinaryWriter writer);
        void SetData(BinaryReader reader);

    }
}
