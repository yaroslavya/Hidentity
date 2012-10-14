using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hidentity.Configuration;

namespace Hidentity
{
    /// <summary>
    /// Does all the hard work with reflection.
    /// </summary>
    public static class ReflectionHelper
    {
        public static int GetValue<T>(this T obj, Substitutable property)
        {
            var prop = obj.GetType().GetProperty(property.PropertyName);
            return (int)prop.GetValue(obj, null);
        }

        public static void SetValue<T>(this T obj, Substitutable property, int setValue)
        {
            var prop = obj.GetType().GetProperty(property.PropertyName);
            prop.SetValue(obj, setValue, null);
        }
    }
}
