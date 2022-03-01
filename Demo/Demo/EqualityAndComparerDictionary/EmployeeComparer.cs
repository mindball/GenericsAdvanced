using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.EqualityAndComparerDictionary
{
    public class EmployeeComparer : IEqualityComparer<Employee>, IComparer<Employee>
    {
        #region IEqualityComparer

        public bool Equals(Employee x, Employee y) => String.Equals(x.Name, y.Name);

        public int GetHashCode(Employee obj) => obj.Name.GetHashCode();

        #endregion

        #region IComparer
        //x < y return -1
        //x == y return 0
        //x > y return 1

        public int Compare(Employee x, Employee y)
        {
            return string.Compare(x.Name, y.Name);
        }
        #endregion
    }
}
