using System;
using System.Reflection;

namespace Dotnet.Benchmarks
{
    public static class IObjectExtensions
    {
        public static T GetValue<T>(this IObject obj, string propertyName)
        {
            return (T)obj.GetValue(propertyName);
        }

        public static void SetUsingReflection(this object obj, string propName, object value)
        {
            // Get the Type information
            Type type = obj.GetType();

            // Get the property information
            PropertyInfo propertyInfo = type.GetProperty(propName);

            // Set the property value
            propertyInfo?.SetValue(obj, value);

        }

        public static object GetUsingReflection(this object obj, string propName)
        {
            // Get the Type information
            Type type = obj.GetType();

            // Get the property information
            PropertyInfo propertyInfo = type.GetProperty(propName);

            // Set the property value
            if (propertyInfo != null)
            {
                return propertyInfo.GetValue(obj);
            }

            return null;
        }
    }
}
