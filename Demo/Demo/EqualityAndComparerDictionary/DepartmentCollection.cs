using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.EqualityAndComparerDictionary
{
    public class DepartmentCollection : SortedDictionary<string, SortedSet<Employee>>
    {
        public DepartmentCollection Add(string departmentName, Employee employee)
        {
            if(!ContainsKey(departmentName))
            {
                //doesnt know how to sort SortedSet<Employee>
                //this.Add(departmentName, new SortedSet<Employee>());
                Add(departmentName, new SortedSet<Employee>(new EmployeeComparer()));
            }

            this[departmentName].Add(employee);
            return this;
        }
    }
}
