using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Helpers
{
    public class PaginationList<T> : List<T>
    {
        public bool HasNext => CurrentPage < TotalPages ? true : false;
        public bool HasPrev => CurrentPage > 1 ? true : false;
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }

        public PaginationList(int totalPages, int currentPage, int pageSize, List<T> items)
        {
            TotalPages = totalPages;
            CurrentPage = currentPage;
            PageSize = pageSize;

            AddRange(items);
        }

        public static async Task<PaginationList<T>> CreatePaginationList(int pageNumber, int pageSize, IQueryable<T> results)
        {
            if (results.Count() <= 0) {
                return new PaginationList<T>((int)0, pageNumber, pageSize, new List<T>());
            }

            var totalPages = Math.Ceiling(results.Count() / (double)pageSize);

            if (pageNumber < 0)
            {
                pageNumber = 1;
            }

            if (pageNumber > totalPages)
            {
                pageNumber = (int)totalPages;
            }

            var numberToSkip = (pageNumber - 1) * pageSize;
            results = results.Skip(numberToSkip).Take(pageSize);
            var items = await results.ToListAsync();
            Debug.WriteLine("count: " + items.Count());
            return new PaginationList<T>((int)totalPages, pageNumber, pageSize, items);
        }
    }
}
