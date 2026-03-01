using API_WEBUI_1.Business.Abstract;
using API_WEBUI_1.DTO.DTOs.ClientDTOs;
using API_WEBUI_1.Entity.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_WEBUI_1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController(IGenericService<Client> _clientService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = _clientService.TGetList();
            return Ok(values);
        }

        
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _clientService.TGetById(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            _clientService.TDelete(id);
            return Ok("Client Deleted");
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateClientDTO createClientDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newValue = _mapper.Map<Client>(createClientDto);
            _clientService.TCreate(newValue);
            return Ok("New Client Created");
        }

        [HttpPut]
        public IActionResult Update(UpdateClientDTO updateClientDto)
        {
            var value = _mapper.Map<Client>(updateClientDto);
            _clientService.TUpdate(value);
            return Ok("Client Updated");
        }
    }
}
