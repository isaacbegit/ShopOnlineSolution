using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.API.Extensions;
using ShopOnline.API.Repositories.Contracts;
using ShopOnline.Models.Dtos;

namespace ShopOnline.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository )
        {
                
                this.productRepository = productRepository;

        }   
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetItems()
        {

            try
            {

                var products = await this.productRepository.GetItems();
                var productsCategoires = await this.productRepository.GetCategories();

                if (products == null || productsCategoires == null)
                {
                    return NotFound();
                }
                else
                {
                    var productDtos = products.ConvertToDto(productsCategoires);
                    return Ok(productDtos);
                }
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retriving data from the database");
                
            }
         

        }
    }
}
