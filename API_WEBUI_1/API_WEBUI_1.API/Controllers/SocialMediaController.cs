using API_WEBUI_1.Business.Abstract;
using API_WEBUI_1.DTO.DTOs.SocialMediaDtos;
using API_WEBUI_1.Entity.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API_WEBUI_1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly IGenericService<SocialMedia> _socialMediaService;
        private readonly IMapper _mapper;

        public SocialMediaController(IGenericService<SocialMedia> socialMediaService, IMapper mapper)
        {
            _socialMediaService = socialMediaService;
            _mapper = mapper;
        }

        // Get all social media entries
        [HttpGet]
        public IActionResult Get()
        {
            var values = _socialMediaService.TGetList();
            return Ok(values);
        }

        // Get by ID
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _socialMediaService.TGetById(id);
            return Ok(value);
        }

        // Delete by ID
        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            _socialMediaService.TDelete(id);
            return Ok("Social media entry deleted");
        }

        // Create new social media entry
        [HttpPost]
        public IActionResult Create([FromBody] CreateSocialMediaDto createSocialMediaDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newValue = _mapper.Map<SocialMedia>(createSocialMediaDto);
            _socialMediaService.TCreate(newValue);
            return Ok("New social media entry created");
        }

        // Update social media entry
        [HttpPut]
        public IActionResult Update(UpdateSocialMediaDto updateSocialMediaDto)
        {
            var value = _mapper.Map<SocialMedia>(updateSocialMediaDto);
            _socialMediaService.TUpdate(value);
            return Ok("Social media entry updated");
        }
    }
}
