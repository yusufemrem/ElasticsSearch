using Elasticsearch.API.DTOs;
using Elasticsearch.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Elasticsearch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseController
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }
        [HttpPost("Save")]
        public async Task<IActionResult> Save(ProductCreateDto request)
        {
            return CreateActionResult(await _productService.SaveAsync(request));
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update(ProductUpdateDto request)
        {
            return CreateActionResult(await _productService.UpdateAsync(request));
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return CreateActionResult(await _productService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            return CreateActionResult(await _productService.GetByIdAsync(id));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            return CreateActionResult(await _productService.DeleteAsync(id));
        }
    }
}
