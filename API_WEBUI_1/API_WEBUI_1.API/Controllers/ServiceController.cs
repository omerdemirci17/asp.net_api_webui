using API_WEBUI_1.Business.Abstract;
using API_WEBUI_1.DTO.DTOs.ServicesDTOs;
using API_WEBUI_1.Entity.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API_WEBUI_1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IGenericService<Service> _serviceService;
        private readonly IMapper _mapper;

        public ServiceController(IGenericService<Service> serviceService, IMapper mapper)
        {
            _serviceService = serviceService;
            _mapper = mapper;
        }

        // Get all services
        [HttpGet]
        public IActionResult Get()
        {
            var values = _serviceService.TGetList();
            return Ok(values);
        }

        // Get service by ID
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _serviceService.TGetById(id);
            return Ok(value);
        }

        // Delete service by ID
        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            _serviceService.TDelete(id);
            return Ok("Service deleted");
        }

        // Create new service
        [HttpPost]
        public IActionResult Create([FromBody] CreateServiceDTO createServiceDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newValue = _mapper.Map<Service>(createServiceDto);
            _serviceService.TCreate(newValue);
            return Ok("New service created");
        }

        // Update service
        [HttpPut]
        public IActionResult Update(UpdateServiceDTO updateServiceDto)
        {
            var value = _mapper.Map<Service>(updateServiceDto);
            _serviceService.TUpdate(value);
            return Ok("Service updated");
        }
    }
}
