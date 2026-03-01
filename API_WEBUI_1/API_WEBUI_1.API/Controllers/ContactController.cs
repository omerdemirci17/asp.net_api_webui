using API_WEBUI_1.Business.Abstract;
using API_WEBUI_1.DTO.DTOs.ContactDtos;
using API_WEBUI_1.Entity.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API_WEBUI_1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IGenericService<Contact> _contactService;
        private readonly IMapper _mapper;

        public ContactController(IGenericService<Contact> contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        // Get all contacts
        [HttpGet]
        public IActionResult Get()
        {
            var values = _contactService.TGetList();
            return Ok(values);
        }

        // Get contact by ID
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _contactService.TGetById(id);
            return Ok(value);
        }

        // Delete contact
        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            _contactService.TDelete(id);
            return Ok("Contact Deleted");
        }

        // Create new contact
        [HttpPost]
        public IActionResult Create([FromBody] CreateContactDto createContactDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newValue = _mapper.Map<Contact>(createContactDto);
            _contactService.TCreate(newValue);
            return Ok("New Contact Created");
        }

        // Update contact
        [HttpPut]
        public IActionResult Update(UpdateContactDto updateContactDto)
        {
            var value = _mapper.Map<Contact>(updateContactDto);
            _contactService.TUpdate(value);
            return Ok("Contact Updated");
        }
    }
}
