using Microsoft.AspNetCore.Mvc;
using Model;

namespace ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly InventoryService _inventoryService;

        public ProductController(InventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] ProductDto productDto)
        {
            try
            {
                // Add the product using InventoryService
                await _inventoryService.AddProduct(productDto);

                return Ok("Product added successfully.");
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
