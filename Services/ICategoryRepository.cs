using E_Commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Services
{
    public interface ICategoryRepository
    {
        public Task<IEnumerable<Category>> GetAllCategories();
        public Task<Category> GetCategoryById(Guid categoryId);
        public void CreateCategory(Category category);

        public Task<bool> IsCategoryIdExist(Guid categoryId);

        public void AddProductItemToCategory(Guid categoryId, ProductItem productItem);

        public void DeleteCategory(Category category);
        public Task<bool> SaveAsync();
    }
}
