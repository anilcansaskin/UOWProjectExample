using Microsoft.AspNetCore.Mvc;
using UOW.BusinessLayer.Categories;
using UOW.DtoLayer.CategoryDto;

namespace UOW.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_categoryService.GetAll());
        }

        [HttpPost]
        public IActionResult Create(CreateCategoryDto dto)
        {
            return Ok(_categoryService.Add(dto));
        }
    }
}
