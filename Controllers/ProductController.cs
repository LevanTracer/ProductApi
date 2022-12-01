using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        } 

        
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAllList()
        {
            var result=await _productService.GetAllList();
            return Ok(result);
        }
        [HttpGet("id")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var result=await _productService.GetProductById(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
        [HttpPost("addproduct")]
        public async Task<ActionResult<List<Product>>> PostProduct(Product product)
        {
            await _productService.PostProduct(product);
            if (product == null)
                return BadRequest("Not available");
            return Ok(await _productService.GetAllList());
                   
        }  
        [HttpDelete]
        public async Task<ActionResult<List<Product>>> DeleteProductById(int id)
        {
           var result=await _productService.DeleteProductById(id); 
            if (result == null)
                return BadRequest("Not Available");
            return Ok(result);
        }
        [HttpPut]
        public async Task<ActionResult<List<Product>>> UpdateProduct(int id, Product product)
        {
            var result=await _productService.UpdateProduct(id, product);
            if (result == null)
                return BadRequest("Not available");
            return Ok(result);
        }
       
    }
}
