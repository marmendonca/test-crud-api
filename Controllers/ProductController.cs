using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestCrud.Infra.Interfaces;
using TestCrud.Models;
using TestCrud.Models.Dtos;

namespace TestCrud.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Product> GetAll([FromServices] IProductRepository productRepository)
        {
            return productRepository.GetAll();
        }

        [Route("{id}")]
        [HttpGet]
        public ActionResult<Product> GetById(long id, [FromServices] IProductRepository productRepository)
        {
            var product = productRepository.GetById(id);

            if (product == null) return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public ActionResult<Product> Save([FromBody] ProductSaveDto productSave, [FromServices] IProductRepository productRepository)
        {
            var product = productRepository.Save(productSave);
            return Ok(product);
        }

        [HttpPut]
        public ActionResult<ProductDto> Update([FromBody] ProductDto dto, [FromServices] IProductRepository productRepository)
        {
            var product = productRepository.GetById(dto.Id);
            if (product != null)
            {
                productRepository.Update(product);
                return Ok(product);
            }
                
            return NotFound();
        }

        [Route("{id}")]
        [HttpDelete]
        public void Delete(long id, [FromServices] IProductRepository productRepository)
        {
            productRepository.Delete(id);
        }
    }
}
