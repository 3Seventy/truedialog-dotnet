using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;

namespace TrueDialog.Helpers
{
    internal static class ObjectHelper
    {
        public static IDictionary<string, object> ToDictionary(object o)
        {
            if (o == null)
                throw new ArgumentNullException();

            if (o is ExpandoObject)
            {
                var dyn = o as ExpandoObject;

                // ReSharper disable once RedundantCast
                return (IDictionary<string, object>)dyn;
            }

            if (o is IDictionary<string, object>)
                return o as IDictionary<string, object>;

            var rval = new Dictionary<string, object>();

            if (o is System.Collections.IDictionary)
            {
                var dict = o as System.Collections.IDictionary;

                foreach (System.Collections.DictionaryEntry item in dict)
                    rval.Add(item.Key.ToString(), item.Value);
            }
            else
            {
                var props = o.GetType().GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

                foreach (PropertyInfo propInfo in props.Where(p => p.CanRead))
                {
                    object val = propInfo.GetValue(o);

                    rval.Add(propInfo.Name, val);
                }
            }

            return rval;
        }

    }
}
