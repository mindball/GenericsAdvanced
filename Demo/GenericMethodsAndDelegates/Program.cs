using GenericMethodsAndDelegates.Delegate;
using GenericMethodsAndDelegates.Delegate.Extensions;
using GenericMethodsAndDelegates.TypeConverterDemo;
using GenericMethodsAndDelegates.TypeConverterDemo.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericMethodsAndDelegates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region TypeConverter 
            //var buffer = new BufferTypeConverter<double>();

            //ProcessInput(buffer);
            ////before refactoring
            ////var asInts = buffer.AsEnumerableOf<int>();
            ////foreach (var item in asInts)
            ////{
            ////    Console.WriteLine(item);
            ////}

            ////after refactoring
            //foreach (var item in buffer.AsEnumerableOf<double, int>())
            //{
            //    Console.WriteLine(item);
            //}

            ////This situation does not need to pass T, in this case is double parameter
            ////The compile infer what is the type of T parameter
            //buffer.Dump();
            //buffer.Dump<double>(); //still working
            ////buffer.Dump<int>(); //it doesn't make sense 

            //ProcessBuffer(buffer);

            #endregion

            #region Delegate
            var buffer = new BufferDelegate<double>();
            Print printOject = new Print(PrintWriteConsoleObject);
            Print<double> printGeneric = new Print<double>(PrintWriteConsoleGeneric);

            ProcessInput(buffer);

            buffer.Dump(printOject);
            buffer.Dump(printGeneric);

            #endregion
        }

        private static void ProcessBuffer(IBuffer<double> buffer)
        {
            var sum = 0.0;
            Console.WriteLine("Buffer: ");
            while (!buffer.IsEmpty)
            {
                sum += buffer.Read();
            }

            Console.WriteLine(sum);
        }

        private static void ProcessInput(IBuffer<double> buffer)
        {
            while (true)
            {
                var value = 0.0;
                var input = Console.ReadLine();

                if (double.TryParse(input, out value))
                {
                    buffer.Write(value);
                    continue;
                }
                break;
            }
        }

        //generic version
        private static void PrintWriteConsoleGeneric(double val)
        {
            Console.WriteLine(val);
        }
        //boxing version        
        private static void PrintWriteConsoleObject(object val)
        {
            Console.WriteLine(val);
        }
    }
}
