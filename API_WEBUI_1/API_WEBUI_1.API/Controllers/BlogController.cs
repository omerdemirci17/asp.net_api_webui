using API_WEBUI_1.Business.Abstract;
using API_WEBUI_1.DTO.DTOs.BlogDtos;
using API_WEBUI_1.Entity.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API_WEBUI_1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IGenericService<Blog> _blogService;
        private readonly IMapper _mapper;

        public BlogController(IGenericService<Blog> blogService, IMapper mapper)
        {
            _blogService = blogService;
            _mapper = mapper;
        }

        // Get all blogs
        [HttpGet]
        public IActionResult Get()
        {
            var values = _blogService.TGetList();
            return Ok(values);
        }

        // Get blog by ID
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _blogService.TGetById(id);
            return Ok(value);
        }

        // Delete blog
        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            _blogService.TDelete(id);
            return Ok("Blog Deleted");
        }

        // Create new blog
        [HttpPost]
        public IActionResult Create([FromBody] CreateBlogDto createBlogDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newValue = _mapper.Map<Blog>(createBlogDto);
            _blogService.TCreate(newValue);
            return Ok("New Blog Created");
        }

        // Update blog
        [HttpPut]
        public IActionResult Update(UpdateBlogDto updateBlogDto)
        {
            var value = _mapper.Map<Blog>(updateBlogDto);
            _blogService.TUpdate(value);
            return Ok("Blog Updated");
        }
    }
}
