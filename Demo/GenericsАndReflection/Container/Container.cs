using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsАndReflection.Container
{
    /// <summary>
    /// This is a tutorial on reflection code, its purpose is to show how work reflection
    /// by creating a container, so not all error-handling points are included
    /// </summary>
    public class Container
    {
        //Container is map, it consist type of source and type of dest.
        private Dictionary<Type, Type> map = new Dictionary<Type, Type>();

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
            object source = null;
            if (this.map.TryGetValue(sourceType, out Type destinationType))
            {
                source = CreateInstance(destinationType);
            }
            else if (!sourceType.IsAbstract)
            {
                source = CreateInstance(sourceType);
            }
            else if (sourceType.IsGenericType &&
                     this.map.ContainsKey(sourceType.GetGenericTypeDefinition()))
            {
                var destination = this.map[sourceType.GetGenericTypeDefinition()];
                var closedConstructedTyped = destination.MakeGenericType(sourceType.GenericTypeArguments);
                source = CreateInstance(closedConstructedTyped);
            }

            //Good practice is to create custom exception for not exist source type at the container
            return source is null
                ? throw new InvalidOperationException("Could not resolve " + sourceType.FullName)
                : source;
        }

        /// <summary>
        /// Here is one place where Resolve(Type sourceType) is more useful than Resolve<TSource> 
        /// </summary>
        /// <param name="destinationType"></param>
        /// <remarks>
        /// Used a callback Resolve to resolve constructor parameters, in case that is ILogger
        /// </remarks>
        private object CreateInstance(Type destinationType)
        {
            var parameters = destinationType.GetConstructors()
                .OrderByDescending(c => c.GetParameters().Length)
                .First()
                .GetParameters()
                .Select(p => Resolve(p.ParameterType))
                .ToArray();

            return Activator.CreateInstance(destinationType, parameters);
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
