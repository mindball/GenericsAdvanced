using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsАndReflection.Container
{
    public class InvoiceService
    {
        //Test 3 passed when generic type is Employee, before use unbound
        //Test 4 is not passed
        public InvoiceService(IRepository<Employee> repository, ILogger logger)
        {
                
        }

        //Test 4 passed when generic type is Customer and  use unbound case into container class
        public InvoiceService(IRepository<Customer> repository)
        {

        }
    }
}
