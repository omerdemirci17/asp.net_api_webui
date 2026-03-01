using API_WEBUI_1.Business.Abstract;
using API_WEBUI_1.DTO.DTOs.FeaturedServicesDTO;
using API_WEBUI_1.Entity.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API_WEBUI_1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturedServicesController : ControllerBase
    {
        private readonly IGenericService<FeaturedServices> _featuredService;
        private readonly IMapper _mapper;

        public FeaturedServicesController(IGenericService<FeaturedServices> featuredService, IMapper mapper)
        {
            _featuredService = featuredService;
            _mapper = mapper;
        }

        // Get all featured services
        [HttpGet]
        public IActionResult Get()
        {
            var values = _featuredService.TGetList();
            return Ok(values);
        }

        // Get by ID
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _featuredService.TGetById(id);
            return Ok(value);
        }

        // Delete
        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            _featuredService.TDelete(id);
            return Ok("Featured service deleted");
        }

        // Create
        [HttpPost]
        public IActionResult Create([FromBody] CreateFeaturedServicesDTO createFeaturedServicesDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newValue = _mapper.Map<FeaturedServices>(createFeaturedServicesDto);
            _featuredService.TCreate(newValue);
            return Ok("New featured service created");
        }

        // Update
        [HttpPut]
        public IActionResult Update(UpdateFeaturedServicesDTO updateFeaturedServicesDto)
        {
            var value = _mapper.Map<FeaturedServices>(updateFeaturedServicesDto);
            _featuredService.TUpdate(value);
            return Ok("Featured service updated");
        }
    }
}
