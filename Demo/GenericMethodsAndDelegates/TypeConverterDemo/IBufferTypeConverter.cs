using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericMethodsAndDelegates.TypeConverterDemo
{
    public interface IBufferTypeConverter<T> : IEnumerable<T>
    {
        bool IsEmpty { get; }

        void Write(T value);

        IEnumerable<TOutput> AsEnumerable<TOutput>();

        T Read();
    }
}
