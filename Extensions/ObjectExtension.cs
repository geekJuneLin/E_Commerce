using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace E_Commerce.Helpers
{
    public static class ObjectExtension
    {
        public static ExpandoObject ShapeData<T>
            (
                this T source,
                string fields
            )
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var propertyInfoList = new List<PropertyInfo>();

            if (string.IsNullOrWhiteSpace(fields))
            {
                var propertyInfos = typeof(T)
                                    .GetProperties(BindingFlags.IgnoreCase | 
                                                   BindingFlags.Public | 
                                                   BindingFlags.Instance);

                propertyInfoList.AddRange(propertyInfos);
            }
            else
            {
                var fieldAfterSplit = fields.Split(",");

                foreach (var field in fieldAfterSplit)
                {
                    var propertyName = field.Trim();

                    var propertyInfo = typeof(T)
                                        .GetProperty(propertyName,
                                                    BindingFlags.IgnoreCase |
                                                    BindingFlags.Public |
                                                    BindingFlags.Instance);

                    if (propertyInfo == null)
                    {
                        throw new ArgumentException($"{propertyName} cannot be found");
                    }

                    propertyInfoList.Add(propertyInfo);
                }
            }

            var expandoObjects = new ExpandoObject();
            foreach (var propertyInfo in propertyInfoList)
            {
                var propertyValue = propertyInfo.GetValue(source);

                ((IDictionary<string, object>)expandoObjects).Add(propertyInfo.Name, propertyValue);
            }

            return expandoObjects;
        }

        public static bool IsProperyExists<T>
            (
                this T source,
                string key
            )
        {
            PropertyInfo propertyInfo = typeof(T).GetProperty(key,
                                                              BindingFlags.IgnoreCase |
                                                              BindingFlags.Public | 
                                                              BindingFlags.Instance);
            return propertyInfo != null;
        }
    }
}
