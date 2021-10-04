using E_Commerce.Helpers;
using E_Commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Services
{
    public interface IProductItemRepository
    {
        public Task<bool> SaveChanges();
        public Task<PaginationList<ProductItem>> GetProductAllProductItems(int pageNumber, int pageSize, string keyWord, string operatorString, int compareValue, string orderBy);
        public Task<ProductItem> GetProductItemById(Guid id);
        public Task<bool> IsProductItemExists(Guid idf);
        public void DeleteProductItem(ProductItem productItem);
        public void CreateProductItem(ProductItem productItem);
    }
}
