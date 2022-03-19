using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsАndReflection.Container
{
    public class Container
    {
        //Container is map, it consist type of source and type of dest.
        private Dictionary<Type, Type> map = new Dictionary<Type, Type>();

        ///
        /// This aproach For<T> and For(typeof(T)) allow us to work
        // compile time For<T> and
        /// runtime For(typeof(T))
        /// also ContainerBuilder Use same approach
        public ContainerBuilder For<TSource>()
        {
            return For(typeof(TSource));
        }

        //diff version of for
        public ContainerBuilder For(Type sourceType)
        {
            return new ContainerBuilder(this, sourceType);
        }


        public TSource Resolve<TSource>()
        {
            return (TSource)Resolve(typeof(TSource));
        }

        public object Resolve(Type sourceType)
        {
            if (this.map.TryGetValue(sourceType, out Type destinationType))
            {
                return Activator.CreateInstance(destinationType);
            }
            //Good practice is to create custom exception for not exist source type at the container
            throw new InvalidOperationException("Could not resolve " + sourceType.FullName);  
        }

    public class ContainerBuilder
    {
        private Container container;
        private Type sourceType;

        public ContainerBuilder(Container container, Type sourceType)
        {
            this.container = container;
            this.sourceType = sourceType;
        }

        public ContainerBuilder Use<TDestination>()
        {
            return Use(typeof(TDestination));
        }

        public ContainerBuilder Use(Type destinationType)
        {
            this.container.map.Add(sourceType, destinationType);
            return this;
        }


    }
}
}
