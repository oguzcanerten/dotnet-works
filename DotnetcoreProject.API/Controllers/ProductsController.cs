using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DotnetcoreProject.API.DTOs;
using DotnetcoreProject.API.Filters;
using DotnetcoreProject.Core.Models;
using DotnetcoreProject.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotnetcoreProject.API.Controllers
{
    [ValidationFilter]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //throw new Exception("Tüm dataları çekerken bir hata meydana geldi");

            var products = await _productService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<ProductDto>>(products));
        }

        //Action metodu içerisini temiz tut.
        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            return Ok(_mapper.Map<ProductDto>(product));
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpDelete("{id}/category")]
        public async Task<IActionResult> GetWithCategoryById(int id)
        {
            var product = await _productService.GetWithCategoryByIdAsync(id);
            return Ok(_mapper.Map<CategoryWithProductDto>(product));
        }
        [ValidationFilter]
        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            var newproduct = await _productService.AddAsync(_mapper.Map<Product>(productDto));

            return Created(string.Empty, _mapper.Map<ProductDto>(newproduct));
        }
        [HttpPut]

        [ServiceFilter(typeof(NotFoundFilter))]
        public IActionResult Uptade(ProductDto productDto)
        {
            if (string.IsNullOrEmpty(productDto.Id.ToString()) || productDto.Id <= 0)
            {
                throw new Exception("Id alanı gereklidir.");
            }
            var product = _productService.Update(_mapper.Map<Product>(productDto));

            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var product = _productService.GetByIdAsync(id).Result;

            _productService.Remove(product);

            return NoContent();
        }
    }
}