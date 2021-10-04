using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace E_Commerce.Helpers
{
    public static class IEnumerableExtension
    {
        public static IEnumerable<ExpandoObject> ShapeData<T>
            (
                this IEnumerable<T> result,
                string fields
            )
        {

            if (result == null)
            {
                throw new ArgumentNullException(nameof(result));
            }

            var shapedResult = new List<ExpandoObject>();

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
                var valueAfterSplit = fields.Split(",");

                foreach (var value in valueAfterSplit)
                {
                    var propertyName = value.Trim();

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


            foreach (T sourceObject in result)
            {
                var shapedObject = new ExpandoObject();

                foreach (var propertyInfo in propertyInfoList)
                {
                    var propertyValue = propertyInfo.GetValue(sourceObject);

                    ((IDictionary<string, object>)shapedObject).Add(propertyInfo.Name, propertyValue);
                }

                shapedResult.Add(shapedObject);
            }

            return shapedResult;
        }
    }
}
