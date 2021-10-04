using E_Commerce.Data;
using E_Commerce.Extensions;
using E_Commerce.Helpers;
using E_Commerce.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Services
{
    public class ProductItemRepository : IProductItemRepository
    {
        private readonly AppDbContext _dbContext;

        public ProductItemRepository
            (
                AppDbContext context
            )
        {
            _dbContext = context;
        }

        public void CreateProductItem(ProductItem productItem)
        {
            if (productItem == null)
            {
                throw new ArgumentNullException(nameof(productItem));
            }

            _dbContext.ProductItems.Add(productItem);
        }

        public void DeleteProductItem(ProductItem productItem)
        {
            if (productItem == null)
            {
                throw new ArgumentNullException(nameof(productItem));
            }


            _dbContext.ProductItems.Remove(productItem);
        }

        public async Task<PaginationList<ProductItem>> GetProductAllProductItems(int pageNumber, int pageSize, string keyWord, string operatorString, int compareValue, string orderBy)
        {
            IQueryable<ProductItem> results = _dbContext.ProductItems
                                                        .Include(i => i.Category);

            // Keyword filtering
            if (!string.IsNullOrEmpty(keyWord))
            {
                results = results.Where(pi => pi.ProductName.ToLower().Contains(keyWord.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(operatorString))
            {
                results = operatorString switch
                {
                    "greaterThan" => results.Where(pi => pi.Price >= compareValue),
                    "lessThan" => results.Where(pi => pi.Price <= compareValue),
                    _ => results.Where(pi => pi.Price == compareValue)
                };
            }

            if (!string.IsNullOrEmpty(orderBy))
            {
                results = results.ApplySort(orderBy);
            }

            return await PaginationList<ProductItem>.CreatePaginationList(pageNumber, pageSize, results);
        }

        public async Task<ProductItem> GetProductItemById(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id));
            }

            IQueryable<ProductItem> result = _dbContext.ProductItems
                                                       .Include(p => p.Category);

            return await result.FirstOrDefaultAsync();
        }

        public async Task<bool> IsProductItemExists(Guid id)
        {
            return await _dbContext.ProductItems.AnyAsync(pi => pi.Id == id);
        }

        public async Task<bool> SaveChanges()
        {
            return (await _dbContext.SaveChangesAsync() > 0);
        }
    }
}
