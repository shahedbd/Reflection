using ReflectionExample.Model;
using System;
using System.Linq;
using System.Reflection;

namespace ReflectionExample
{
    public static class ReflectionDetails
    {
        public static void GetProperty()
        {
            var props = typeof(Win32_Process)
                .GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                .OrderBy(x => x.MetadataToken);

            foreach (var item in props)
            {
                Console.WriteLine(item.Name + ": " + item.PropertyType);
            }
        }



        public static void SampleExample()
        {
            // Using GetType to obtain type information:  
            int i = 42;
            Type type = i.GetType();
            Console.WriteLine(type);


            // Using Reflection to get information from an Assembly:  
            Assembly info = typeof(Int32).Assembly;
            Console.WriteLine(info);
        }

    }
}
