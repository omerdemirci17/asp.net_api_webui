using API_WEBUI_1.Business.Abstract;
using API_WEBUI_1.DTO.DTOs.BannerDtos;
using API_WEBUI_1.Entity.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API_WEBUI_1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannerController : ControllerBase
    {
        private readonly IGenericService<Banner> _bannerService;
        private readonly IMapper _mapper;

        public BannerController(IGenericService<Banner> bannerService, IMapper mapper)
        {
            _bannerService = bannerService;
            _mapper = mapper;
        }

        // Get all banners
        [HttpGet]
        public IActionResult Get()
        {
            var values = _bannerService.TGetList();
            return Ok(values);
        }

        // Get banner by ID
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _bannerService.TGetById(id);
            return Ok(value);
        }

        // Delete banner by ID
        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            _bannerService.TDelete(id);
            return Ok("Banner Deleted");
        }

        // Create new banner
        [HttpPost]
        public IActionResult Create([FromBody] CreateBannerDto createBannerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newValue = _mapper.Map<Banner>(createBannerDto);
            _bannerService.TCreate(newValue);
            return Ok("New Banner Created");
        }

        // Update banner
        [HttpPut]
        public IActionResult Update(UpdateBannerDto updateBannerDto)
        {
            var value = _mapper.Map<Banner>(updateBannerDto);
            _bannerService.TUpdate(value);
            return Ok("Banner Updated");
        }
    }
}
