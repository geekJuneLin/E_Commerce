using E_Commerce.Data;
using E_Commerce.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            IQueryable<Category> categories = _context.Categories.Include(c => c.ProductItems);

            return await categories.ToListAsync();
        }

        public async Task<Category> GetCategoryById(Guid categoryId)
        {
            IQueryable<Category> results = _context.Categories.Include(c => c.ProductItems);
            return await results.FirstOrDefaultAsync(c => c.CategoryId == categoryId);
        }

        public async Task<bool> IsCategoryIdExist(Guid categoryId)
        {
            return await _context.Categories.AnyAsync(c => c.CategoryId == categoryId);
        }

        public async void AddProductItemToCategory(Guid categoryId, ProductItem productItem)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.CategoryId == categoryId);
            category.ProductItems.Add(productItem);
        }

        public void DeleteCategory(Category category)
        {
            _context.Categories.Remove(category);
        }

        public void CreateCategory(Category category)
        {
            _context.Categories.AddAsync(category);
        } 

        public async Task<bool> SaveAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }
    }
}
