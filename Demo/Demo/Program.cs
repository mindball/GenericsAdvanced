using Demo.EqualityAndComparerDictionary;
using Demo.IEnumerableDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region IEnumerable
            //var buffer = new Buffer<double>();
            //ProcessInput(buffer);
            //foreach (var item in buffer)
            //{
            //    Console.WriteLine(item);
            //}

            var buffer = new Buffer<int>();
            ProcessInput(buffer);
            foreach (var item in buffer)
            {
                Console.WriteLine(item);
            }

            //ProcessBuffer(buffer);
            #endregion

            #region Collection with Equality and compare
            //allow repetitions List<Employee>
            SortedDictionary<string, List<Employee>> withRepeat = new SortedDictionary<string, List<Employee>>();

            //HashSet compare by default a reference and now Dani and Dani is exist(without equality and comparer)
            //allow repetitions List<Employee> but not implement a EmployeeComparer
            var departs = new SortedDictionary<string, HashSet<Employee>>();
            departs.Add("Sales", new HashSet<Employee>());
            departs["Sales"].Add(new Employee() { Name = "Dani" });
            departs["Sales"].Add(new Employee() { Name = "Dani" });
            departs["Sales"].Add(new Employee() { Name = "Ivan" });

            departs.Add("Accounting", new HashSet<Employee>());
            departs["Accounting"].Add(new Employee() { Name = "Dani" });
            departs["Accounting"].Add(new Employee() { Name = "Dani" });
            departs["Accounting"].Add(new Employee() { Name = "Ivan" });

            //foreach (var depart in departs)
            //{
            //    Console.WriteLine(depart.Key);

            //    foreach (var empl in depart.Value)
            //    {
            //        Console.Write("\t");
            //        Console.WriteLine(empl.Name);
            //    }
            //}

            //disallow repetitions List<Employee>, implement EmployeeComparer, List<Employee> is not sorted
            departs.Clear();
            departs = new SortedDictionary<string, HashSet<Employee>>();
            departs.Add("Sales", new HashSet<Employee>(new EmployeeComparer()));
            departs["Sales"].Add(new Employee() { Name = "Dani" });
            departs["Sales"].Add(new Employee() { Name = "Dani" });
            departs["Sales"].Add(new Employee() { Name = "Ivan" });
            departs["Sales"].Add(new Employee() { Name = "Ivana" });
            departs["Sales"].Add(new Employee() { Name = "Iva" });
            foreach (var depart in departs)
            {
                Console.WriteLine(depart.Key);

                foreach (var empl in depart.Value)
                {
                    Console.Write("\t");
                    Console.WriteLine(empl.Name);
                }
            }

            Console.WriteLine("-----------------------------------");

            // disallow repetitions List<Employee>, implement EmployeeComparer, List<Employee> is sorted (public int Compare(Employee x, Employee y))         
            var departsOrdering = new SortedDictionary<string, SortedSet<Employee>>();
            departsOrdering.Add("Sales", new SortedSet<Employee>(new EmployeeComparer()));
            departsOrdering["Sales"].Add(new Employee() { Name = "Dani" });
            departsOrdering["Sales"].Add(new Employee() { Name = "Dani" });
            departsOrdering["Sales"].Add(new Employee() { Name = "Ivan" });
            departsOrdering["Sales"].Add(new Employee() { Name = "Ivana" });
            departsOrdering["Sales"].Add(new Employee() { Name = "Iva" });

            foreach (var depart in departsOrdering)
            {
                Console.WriteLine(depart.Key);

                foreach (var empl in depart.Value)
                {
                    Console.Write("\t");
                    Console.WriteLine(empl.Name);
                }
            }

            Console.WriteLine("--------------------Short way-------------------");
            var departsOrderingShort = new DepartmentCollection();
            departsOrderingShort.Add("Sales", new Employee() { Name = "Dani" })
                                .Add("Sales", new Employee() { Name = "Dani" })
                                .Add("Sales", new Employee() { Name = "Ivan" })
                                .Add("Sales", new Employee() { Name = "Ivana" })
                                .Add("Sales", new Employee() { Name = "Iva" });

            foreach (var depart in departsOrdering)
            {
                Console.WriteLine(depart.Key);

                foreach (var empl in depart.Value)
                {
                    Console.Write("\t");
                    Console.WriteLine(empl.Name);
                }
            }

            #endregion

            Console.ReadLine();
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
    }
}



