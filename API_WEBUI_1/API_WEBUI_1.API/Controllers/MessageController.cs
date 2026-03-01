using API_WEBUI_1.Business.Abstract;
using API_WEBUI_1.DTO.DTOs.MessageDtos;
using API_WEBUI_1.Entity.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API_WEBUI_1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IGenericService<Message> _messageService;
        private readonly IMapper _mapper;

        public MessageController(IGenericService<Message> messageService, IMapper mapper)
        {
            _messageService = messageService;
            _mapper = mapper;
        }

        // Get all messages
        [HttpGet]
        public IActionResult Get()
        {
            var values = _messageService.TGetList();
            return Ok(values);
        }

        // Get message by ID
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _messageService.TGetById(id);
            return Ok(value);
        }

        // Delete message by ID
        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            _messageService.TDelete(id);
            return Ok("Message deleted");
        }

        // Create new message
        [HttpPost]
        public IActionResult Create([FromBody] CreateMessageDto createMessageDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newValue = _mapper.Map<Message>(createMessageDto);
            _messageService.TCreate(newValue);
            return Ok("New message created");
        }

        // Update message
        [HttpPut]
        public IActionResult Update(UpdateMessageDto updateMessageDto)
        {
            var value = _mapper.Map<Message>(updateMessageDto);
            _messageService.TUpdate(value);
            return Ok("Message updated");
        }
    }
}
