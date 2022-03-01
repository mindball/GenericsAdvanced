using System;

namespace Demo.EqualityAndComparerDictionary
{
    public class Employee
    {
        public Employee()
        {
            Id = Guid.NewGuid().ToString();

        }
        public string Id { get; set; }

        public string Name { get; set; }

        public string DepartmentId { get; set; }
    }
}
