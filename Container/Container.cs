//using System;

//namespace DeveloperSample.Container
//{
//    public class Container
//    {
//        public void Bind(Type interfaceType, Type implementationType) => throw new NotImplementedException();
//        public T Get<T>() => throw new NotImplementedException();
//    }
//}

using System;
using System.Collections.Generic;
using System.Reflection;

namespace DeveloperSample.Container
{
    public class Container
    {
        private readonly Dictionary<Type, Type> _bindings;

        public Container()
        {
            _bindings = new Dictionary<Type, Type>();
        }

        public void Bind(Type interfaceType, Type implementationType)
        {
            if (interfaceType == null || implementationType == null)
            {
                throw new ArgumentNullException("Arguments cannot be null");
            }

            if (!interfaceType.IsInterface)
            {
                throw new ArgumentException("First argument must be an interface type");
            }

            if (!interfaceType.IsAssignableFrom(implementationType))
            {
                throw new ArgumentException("The implementation type does not implement the interface");
            }

            _bindings[interfaceType] = implementationType;
        }

        public T Get<T>()
        {
            var type = typeof(T);
            if (_bindings.TryGetValue(type, out var implementationType))
            {
                return (T)Activator.CreateInstance(implementationType);
            }

            throw new InvalidOperationException($"No binding found for type {type.FullName}");
        }
    }
}
