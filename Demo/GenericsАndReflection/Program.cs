using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsАndReflection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ClosedConstructedTyped 
            var employeeList = CreateCollectionCCT(typeof(List<Employee>));
            Console.WriteLine(employeeList);

            var employeeListUnbound = CreateCollectionUBGT(typeof(List<>), typeof(Employee));
            var genericArguments = employeeListUnbound.GetType().GenericTypeArguments;
            Console.Write(employeeListUnbound.GetType().Name);
            foreach (var arg in genericArguments)
            {
                Console.Write($"[{arg.Name}]");
            }
            ;
        }

        //ClosedConstructedTyped 
        private static object CreateCollectionCCT(Type type)
        {
            return Activator.CreateInstance(type);
        }

        //Unbound generic type 
        private static object CreateCollectionUBGT(Type collectionType, Type itemType)
        {
            var closedType = collectionType.MakeGenericType(itemType);
            return Activator.CreateInstance(closedType);
        }
    }

    public class Employee
    {
        public string Name { get; set; }
        
    }

    public class Person
    {
        public string Name { get; set; }
    }
}
