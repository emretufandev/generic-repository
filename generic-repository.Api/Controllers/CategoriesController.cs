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
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult GetList()
        {
            var result = _categoryService.GetList();

            return Ok(result);
        }

        [HttpGet("{categoryId}/products")]
        public IActionResult GetProducts(int categoryId)
        {
            var result = _categoryService.GetProducts(categoryId);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            var result = _categoryService.Create(category);

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPut]
        public IActionResult Update(Category category)
        {
            var result = _categoryService.Update(category);

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _categoryService.Delete(id);

            if (result.Success)
                return NoContent();

            return BadRequest(result);
        }
    }
}
