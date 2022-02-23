using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceTopics
{
    public class TWithoutGeneric
    {
        //Кога имплементираме метод и класа не е generic трябва да упоменем <T>
        public virtual TReturn TRetrieveValue<TReturn>(string sql, TReturn defaultValue)
        {
            var valueType = defaultValue;
            return valueType;
        }
    }

    public class TGeneric<T> : TWithoutGeneric
    {
        //generic class
        public T RetrieveValue(string sql, T defaultValue)
        {
            T valueType = defaultValue;
            return valueType;
        }

#pragma warning disable CS0693 // Type parameter has the same name as the type parameter from outer type
        public override T TRetrieveValue<T>(string sql, T defaultValue)
#pragma warning restore CS0693 // Type parameter has the same name as the type parameter from outer type
        {
            return base.TRetrieveValue(sql, defaultValue);
        }
    }
}
