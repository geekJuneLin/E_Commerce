using AutoMapper;
using E_Commerce.Dtos;
using E_Commerce.Helpers;
using E_Commerce.Models;
using E_Commerce.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using static E_Commerce.Helpers.IHeaderLinkGenerator;

namespace E_Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductItemController : ControllerBase
    {
        private readonly IProductItemRepository _productItemRepository;
        private readonly IMapper _mapper;
        private readonly IHeaderLinkGenerator _linkGenerator;

        public ProductItemController
            (
                IProductItemRepository productItemRepository,
                IMapper mapper,
                IHeaderLinkGenerator linkGenerator
            )
        {
            _productItemRepository = productItemRepository;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }


        // Get all product items
        [AllowAnonymous]
        [HttpGet(Name = "GetAllProductItems")]
        public async Task<IActionResult> GetAllProductItems
            (
                [FromQuery]FilterParameters filterParameters,
                [FromQuery]PaginationParameters paginationParameters
            )
        {
            Debug.WriteLine($"pageNumber: {paginationParameters.PageNumber}");

            var productItemsFromRepo = await _productItemRepository.GetProductAllProductItems(
                                                                    paginationParameters.PageNumber,
                                                                    paginationParameters.PageSize,
                                                                    filterParameters.KeyWord,
                                                                    filterParameters.Operator,
                                                                    filterParameters.CompareValue,
                                                                    filterParameters.OrderBy);

            if (productItemsFromRepo.Count() <= 0)
            {
                return NotFound("No items found");
            }

            var previousUrl = productItemsFromRepo.HasPrev ? 
                              _linkGenerator.GenerateLink(PageType.Previous, 
                                                          "GetAllProductItems", 
                                                          paginationParameters, 
                                                          new {
                                                             pageSize = paginationParameters.PageSize,
                                                             pageNumber = paginationParameters.PageNumber - 1,
                                                             keyWord = filterParameters.KeyWord
                                                          }) : 
                              null;

            var nextUrl = productItemsFromRepo.HasNext ?
                          _linkGenerator.GenerateLink(PageType.Next, 
                                                     "GetAllProductItems", 
                                                     paginationParameters,
                                                     new { 
                                                        pageSize = paginationParameters.PageSize,
                                                        pageNumber = paginationParameters.PageNumber + 1,
                                                        keyWord = filterParameters.KeyWord
                                                     }) :
                         null;

            //Debug.WriteLine($"Prev Url: {previousUrl} Next Url: {nextUrl}");

            var response = new { 
                previousUrl = previousUrl,
                nextUrl = nextUrl,
                totalPages = productItemsFromRepo.TotalPages,
                totalCount = productItemsFromRepo.Count,
                currentPage = productItemsFromRepo.CurrentPage
            };

            Response.Headers.Add("x-pagination", JsonConvert.SerializeObject(response));

            var productItemsDto = _mapper.Map<IEnumerable<ProductItemDto>>(productItemsFromRepo);

            return Ok(productItemsDto.ShapeData(filterParameters.Fields));
        }

        // Get product item by {id}
        [AllowAnonymous]
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetProductItemById
            (
                [FromRoute]Guid id,
                [FromQuery]FilterParameters filterParameters
            )
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Please enter the ProductItem Id");
            }

            var productItemFromRepo = await _productItemRepository.GetProductItemById(id);

            if (productItemFromRepo == null)
            {
                return BadRequest("ProductItem cannot found");
            }

            var productItemDto = _mapper.Map<ProductItemDto>(productItemFromRepo);

            return Ok(productItemDto.ShapeData(filterParameters.Fields));
        }

        // Delete a product item by {id}
        [Authorize(Roles = "Admin")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductItemById
            (
                [FromRoute]Guid id
            )
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Please enter the ProductItem Id");
            }

            var productItemFromRepo = await _productItemRepository.GetProductItemById(id);

            if (productItemFromRepo == null)
            {
                return BadRequest("ProductItem cannot found");
            }

            _productItemRepository.DeleteProductItem(productItemFromRepo);
            await _productItemRepository.SaveChanges();

            return NoContent();
        }

        // Create a new product item
        [Authorize(Roles = "Admin")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        public async Task<IActionResult> CreateProductItem
            (
                [FromBody]ProductItemCreateDto productItemCreateDto
            )
        {
            if (productItemCreateDto == null)
            {
                return BadRequest("Please specify the ProductItem");
            }

            Debug.WriteLine($"cId: {productItemCreateDto.CategoryId}");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productItemToCreate = _mapper.Map<ProductItem>(productItemCreateDto);

            _productItemRepository.CreateProductItem(productItemToCreate);
            await _productItemRepository.SaveChanges();

            var productItemDto = _mapper.Map<ProductItemDto>(productItemToCreate);

            return Ok(productItemDto);
        }

        // Update a product item by {productId}
        [Authorize(Roles = "Admin")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPut("{productId}")]
        public async Task<IActionResult> UpdateProductItemById
            (
                [FromRoute]Guid productId,
                [FromBody]ProductItemUpdateDto productItemUpdateDto
            )
        {
            if (!await _productItemRepository.IsProductItemExists(productId))
            {
                return NotFound($"Product Item with Id {productId}  not found");
            }

            if (productItemUpdateDto == null)
            {
                return BadRequest("Please specify the ProductItem");
            }

            var productItemFromRepo = await _productItemRepository.GetProductItemById(productId);

            _mapper.Map(productItemUpdateDto, productItemFromRepo);

            await _productItemRepository.SaveChanges();

            return NoContent();
        }
    }
}
