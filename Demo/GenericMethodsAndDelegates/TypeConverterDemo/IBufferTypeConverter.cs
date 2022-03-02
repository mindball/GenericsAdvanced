using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericMethodsAndDelegates.TypeConverterDemo
{
    public interface IBufferTypeConverter<T> : IBuffer<T>
    {
        //Remove from IBuffer, because it is used in some exceptional cases
        //Refactor move method to extension method
        //IEnumerable<TOutput> AsEnumerableOf<TOutput>();      
    }
}
