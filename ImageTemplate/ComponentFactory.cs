using System;
using System.Collections.Generic;

namespace ImageTemplate
{
    public static class ComponentFactory
    {
        private static Dictionary<string, Type> Registry = new Dictionary<string, Type>();
        public static void Register<T>(String id)
        {
            var type = typeof(T);
            if (type.IsAbstract || type.IsInterface)
            {
                throw new ArgumentException("Cannot create instance of interface or abstract class");
            }
            if (type as IComponent == null)
            {
                throw new ArgumentException("Cannot register non-IComponent type");
            }
            Registry.Add(id.ToLower(), type);
        }
        public static IComponent Create<T>(String id)
        {
            Type type;
            if (!Registry.TryGetValue(id.ToLower(), out type))
            {
                throw new Exception("Unsupported component id: " + id);
            }
            return (IComponent)Activator.CreateInstance(type);
        }
    }
}