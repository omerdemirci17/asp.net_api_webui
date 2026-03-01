using API_WEBUI_1.Business.Abstract;
using API_WEBUI_1.DTO.DTOs.BlogCategoryDtos;
using API_WEBUI_1.Entity.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API_WEBUI_1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogCategoryController : ControllerBase
    {
        private readonly IGenericService<BlogCategory> _blogCategoryService;
        private readonly IMapper _mapper;

        public BlogCategoryController(IGenericService<BlogCategory> blogCategoryService, IMapper mapper)
        {
            _blogCategoryService = blogCategoryService;
            _mapper = mapper;
        }

        // Get all
        [HttpGet]
        public IActionResult Get()
        {
            var values = _blogCategoryService.TGetList();
            return Ok(values);
        }

        // Get by ID
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _blogCategoryService.TGetById(id);
            return Ok(value);
        }

        // Delete
        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            _blogCategoryService.TDelete(id);
            return Ok("Blog Category Deleted");
        }

        // Create
        [HttpPost]
        public IActionResult Create([FromBody] CreateBlogCategoryDto createBlogCategoryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newValue = _mapper.Map<BlogCategory>(createBlogCategoryDto);
            _blogCategoryService.TCreate(newValue);
            return Ok("New Blog Category Created");
        }

        // Update
        [HttpPut]
        public IActionResult Update(UpdateBlogCategoryDto updateBlogCategoryDto)
        {
            var value = _mapper.Map<BlogCategory>(updateBlogCategoryDto);
            _blogCategoryService.TUpdate(value);
            return Ok("Blog Category Updated");
        }
    }
}
