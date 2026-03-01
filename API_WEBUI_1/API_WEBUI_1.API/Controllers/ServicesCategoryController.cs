using API_WEBUI_1.Business.Abstract;
using API_WEBUI_1.DTO.DTOs.ServicesCategoryDTO;
using API_WEBUI_1.Entity.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API_WEBUI_1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceCategoryController : ControllerBase
    {
        private readonly IGenericService<ServiceCategory> _serviceCategoryService;
        private readonly IMapper _mapper;

        public ServiceCategoryController(IGenericService<ServiceCategory> serviceCategoryService, IMapper mapper)
        {
            _serviceCategoryService = serviceCategoryService;
            _mapper = mapper;
        }

        // Get all service categories
        [HttpGet]
        public IActionResult Get()
        {
            var values = _serviceCategoryService.TGetList();
            return Ok(values);
        }

        // Get service category by ID
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _serviceCategoryService.TGetById(id);
            return Ok(value);
        }

        // Delete service category by ID
        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            _serviceCategoryService.TDelete(id);
            return Ok("Service category deleted");
        }

        // Create new service category
        [HttpPost]
        public IActionResult Create([FromBody] CreateServicesCategoryDTO createServiceCategoryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newValue = _mapper.Map<ServiceCategory>(createServiceCategoryDto);
            _serviceCategoryService.TCreate(newValue);
            return Ok("New service category created");
        }

        // Update service category
        [HttpPut]
        public IActionResult Update(UpdateServicesCategoryDTO updateServiceCategoryDto)
        {
            var value = _mapper.Map<ServiceCategory>(updateServiceCategoryDto);
            _serviceCategoryService.TUpdate(value);
            return Ok("Service category updated");
        }
    }
}
