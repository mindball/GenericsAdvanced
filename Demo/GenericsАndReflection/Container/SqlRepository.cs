﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsАndReflection.Container
{
    public class SqlRepository<T> : IRepository<T>
    {
        public SqlRepository(ILogger logger)
        {
            
        }
    }
}
