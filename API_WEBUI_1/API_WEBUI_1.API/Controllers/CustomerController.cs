using API_WEBUI_1.Business.Abstract;
using API_WEBUI_1.DTO.DTOs.CustomerDTOs;
using API_WEBUI_1.Entity.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API_WEBUI_1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController(IGenericService<Customer> _customerService, IMapper _mapper) : ControllerBase
    {
        //Customer get all of them
        [HttpGet]
        public IActionResult Get()
        {
            var values = _customerService.TGetList();
            return Ok(values);
        }

        //Customer get by id
        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            var value = _customerService.TGetById(id);
            return Ok(value);
        }

        //Customer delete by id
        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            _customerService.TDelete(id);
            
            return Ok("Customer Deleted");
        }

        // Customer Create
        [HttpPost]
        public IActionResult Create([FromBody]CreateCustomerDTO createCustomerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newValue = _mapper.Map<Customer>(createCustomerDto);
            _customerService.TCreate(newValue);
            return Ok("New Customer Created");
        }

        //Customer Update
        [HttpPut]
        public IActionResult Update(UpdateCustomerDTO updateCustomerDto)
        {
            var value = _mapper.Map<Customer>(updateCustomerDto);
            _customerService.TUpdate(value);
            return Ok("Customer Updated");
        }
    }
}
