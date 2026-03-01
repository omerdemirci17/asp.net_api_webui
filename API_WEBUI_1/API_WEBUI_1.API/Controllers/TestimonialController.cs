using API_WEBUI_1.Business.Abstract;
using API_WEBUI_1.DTO.DTOs.TestimonialDtos;
using API_WEBUI_1.Entity.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API_WEBUI_1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly IGenericService<Testimonial> _testimonialService;
        private readonly IMapper _mapper;

        public TestimonialController(IGenericService<Testimonial> testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }

        // Get all testimonials
        [HttpGet]
        public IActionResult Get()
        {
            var values = _testimonialService.TGetList();
            return Ok(values);
        }

        // Get testimonial by ID
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _testimonialService.TGetById(id);
            return Ok(value);
        }

        // Delete testimonial by ID
        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            _testimonialService.TDelete(id);
            return Ok("Testimonial deleted");
        }

        // Create new testimonial
        [HttpPost]
        public IActionResult Create([FromBody] CreateTestimonialDto createTestimonialDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newValue = _mapper.Map<Testimonial>(createTestimonialDto);
            _testimonialService.TCreate(newValue);
            return Ok("New testimonial created");
        }

        // Update testimonial
        [HttpPut]
        public IActionResult Update(UpdateTestimonialDto updateTestimonialDto)
        {
            var value = _mapper.Map<Testimonial>(updateTestimonialDto);
            _testimonialService.TUpdate(value);
            return Ok("Testimonial updated");
        }
    }
}
