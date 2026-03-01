using API_WEBUI_1.Business.Abstract;
using API_WEBUI_1.DTO.DTOs.SubscriberDtos;
using API_WEBUI_1.Entity.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API_WEBUI_1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriberController : ControllerBase
    {
        private readonly IGenericService<Subscriber> _subscriberService;
        private readonly IMapper _mapper;

        public SubscriberController(IGenericService<Subscriber> subscriberService, IMapper mapper)
        {
            _subscriberService = subscriberService;
            _mapper = mapper;
        }

        // Get all subscribers
        [HttpGet]
        public IActionResult Get()
        {
            var values = _subscriberService.TGetList();
            return Ok(values);
        }

        // Get subscriber by ID
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _subscriberService.TGetById(id);
            return Ok(value);
        }

        // Delete subscriber by ID
        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            _subscriberService.TDelete(id);
            return Ok("Subscriber deleted");
        }

        // Create new subscriber
        [HttpPost]
        public IActionResult Create([FromBody] CreateSubscriberDto createSubscriberDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newValue = _mapper.Map<Subscriber>(createSubscriberDto);
            _subscriberService.TCreate(newValue);
            return Ok("New subscriber created");
        }

        // Update subscriber
        [HttpPut]
        public IActionResult Update(UpdateSubscriberDto updateSubscriberDto)
        {
            var value = _mapper.Map<Subscriber>(updateSubscriberDto);
            _subscriberService.TUpdate(value);
            return Ok("Subscriber updated");
        }
    }
}
