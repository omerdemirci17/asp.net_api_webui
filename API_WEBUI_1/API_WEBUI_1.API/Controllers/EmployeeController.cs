using API_WEBUI_1.Business.Abstract;
using API_WEBUI_1.DTO.DTOs.EmployeeDTOs;
using API_WEBUI_1.Entity.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API_WEBUI_1.API.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class EmployeeController(IGenericService<Employee> _aboutService, IMapper _mapper) : ControllerBase
        {
            //About get all of them
            [HttpGet]
            public IActionResult Get()
            {
                var values = _aboutService.TGetList();
                return Ok(values);
            }

            //About get by id
            [HttpGet("{id}")]

            public IActionResult GetById(int id)
            {
                var value = _aboutService.TGetById(id);
                return Ok(value);
            }

            //About delete by id
            [HttpDelete("{id}")]
            public IActionResult DeleteById(int id)
            {
                _aboutService.TDelete(id);
                return Ok("Employee Deleted");
            }

            // About Create
            [HttpPost]
            public IActionResult Create(CreateEmployeeDTO createEmployeeDto)
            {
                var newValue = _mapper.Map<Employee>(createEmployeeDto);
                _aboutService.TCreate(newValue);
                return Ok("New Employee Created");
            }

            //About Update
            [HttpPut]
            public IActionResult Update(UpdateEmployeeDTO updateEmployeeDto)
            {
                var value = _mapper.Map<Employee>(updateEmployeeDto);
                _aboutService.TUpdate(value);
                return Ok("Employee Updated");
            }
        }
}
