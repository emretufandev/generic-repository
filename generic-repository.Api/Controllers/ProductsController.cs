using generic_repository.Business.Abstract;
using generic_repository.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace generic_repository.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetList()
        {
            var result = _productService.GetList();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            var result = _productService.Create(product);

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPut]
        public IActionResult Update(Product product)
        {
            var result = _productService.Update(product);

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _productService.Delete(id);

            if (result.Success)
                return NoContent();

            return BadRequest(result);
        }
    }
}
