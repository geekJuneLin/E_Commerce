using AutoMapper;
using E_Commerce.Dtos;
using E_Commerce.Models;
using E_Commerce.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductItemRepository _productItemRepository;
        private readonly IMapper _mapper;

        public CategoryController
            (
                ICategoryRepository categoryRepository,
                IProductItemRepository productItemRepository,
                IMapper mapper
            )
        {
            _categoryRepository = categoryRepository;
            _productItemRepository = productItemRepository;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryRepository.GetAllCategories();

            if (categories.Count() <= 0)
            {
                return NotFound("No categories found");
            }

            var categoryDtos = _mapper.Map<IEnumerable<CategoryDto>>(categories);

            return Ok(categoryDtos);
        }

        [AllowAnonymous]
        [HttpGet("{categoryId}")]
        public async Task<IActionResult> GetCategoryById
            (
                [FromRoute] Guid categoryId
            )
        {
            Debug.WriteLine($"category: {categoryId}");
            var categoryFromRepo = await _categoryRepository.GetCategoryById(categoryId);

            if (categoryFromRepo == null)
            {
                return BadRequest($"Category of {categoryId} was not found");
            }

            var categoryDto = _mapper.Map<CategoryDto>(categoryFromRepo);

            return Ok(categoryDto);
        }

        // May not needed
        [Authorize(Roles = "Admin")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost("{categoryId}/productItemId/{productItemId}")]
        public async Task<IActionResult> AddProductItem
            (
                [FromRoute]Guid categoryId,
                [FromRoute]Guid productItemId
            )
        {
            if (!await _categoryRepository.IsCategoryIdExist(categoryId) || !await _productItemRepository.IsProductItemExists(productItemId))
            {
                return BadRequest("CategoryId or ProductId were not found");
            }

            var productItemFromRepo = await _productItemRepository.GetProductItemById(productItemId);

            _categoryRepository.AddProductItemToCategory(categoryId, productItemFromRepo);
            await _categoryRepository.SaveAsync();

            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        public async Task<IActionResult> CreateCategory
            (
                [FromBody] CategoryCreateDto categoryCreateDto
            )
        {
            if (categoryCreateDto == null)
            {
                return BadRequest();
            }

            var category = _mapper.Map<Category>(categoryCreateDto);
            _categoryRepository.CreateCategory(category);
            await _categoryRepository.SaveAsync();

            var categoryDto = _mapper.Map<CategoryDto>(category);

            return Ok(categoryDto);
        }

        [Authorize(Roles = "Admin")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPut("{categoryId}")]
        public async Task<IActionResult> UpdateCategory
            (
                [FromRoute] Guid categoryId,
                [FromBody] CategoryUpdateDto categoryUpateDto
            )
        {
            if (categoryUpateDto == null)
            {
                return BadRequest("Please specify the category property");
            }

            if (!await _categoryRepository.IsCategoryIdExist(categoryId))
            {
                return BadRequest("CategoryId was not found");
            }

            var categoryFromRepo = await _categoryRepository.GetCategoryById(categoryId);

            _mapper.Map(categoryUpateDto, categoryFromRepo);

            await _categoryRepository.SaveAsync();

            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpDelete("{categoryId}")]
        public async Task<IActionResult> DeleteCategoryById
            (
                [FromRoute]Guid categoryId
            )
        {
            if (!await _categoryRepository.IsCategoryIdExist(categoryId))
            {
                return BadRequest("CategoryId was not found");
            }

            var categoryFromRepo = await _categoryRepository.GetCategoryById(categoryId);
            _categoryRepository.DeleteCategory(categoryFromRepo);
            await _categoryRepository.SaveAsync();

            return NoContent();
        }
    }
}
