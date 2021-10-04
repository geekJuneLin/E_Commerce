using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using System.Diagnostics;
using E_Commerce.Helpers;

namespace E_Commerce.Extensions
{
    public static class IQueryableExtension
    {
        public static IQueryable<T> ApplySort<T>
            (
                this IQueryable<T> source,
                string orderBy
            )
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (string.IsNullOrWhiteSpace(orderBy))
            {
                return source;
            }

            var orderByAfterSplit = orderBy.Split(",");

            var orderQuery = "";

            foreach (var value in orderByAfterSplit)
            {
                var trimedValue = value.Trim();

                var indexOfSpace = trimedValue.IndexOf(" ");

                string propertyName = indexOfSpace == -1 ? trimedValue : trimedValue.Remove(indexOfSpace);

                var ascending = trimedValue.EndsWith("asc");

                if (source.FirstOrDefault().IsProperyExists(propertyName))
                {
                    orderQuery += 
                            (string.IsNullOrWhiteSpace(orderQuery) ? string.Empty : ", ")
                            + propertyName
                            + (ascending ? " ascending" : " descending");
                }
                else
                {
                    throw new ArgumentException($"{propertyName} does not exists");
                }
            }
            return source.OrderBy(orderQuery);
        }
    }
}
