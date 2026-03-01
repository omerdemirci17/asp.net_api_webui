using API_WEBUI_1.Business.Abstract;
using API_WEBUI_1.DTO.DTOs.DepartmentDTOs;
using API_WEBUI_1.Entity.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API_WEBUI_1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController(IGenericService<Department> _departmentService, IMapper _mapper) : ControllerBase
    {
        //Department get all of them
        [HttpGet]
        public IActionResult Get()
        {
            var values = _departmentService.TGetList();
            return Ok(values);
        }

        //Department get by id
        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            var value = _departmentService.TGetById(id);
            return Ok(value);
        }

        //Department delete by id
        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            _departmentService.TDelete(id);
            return Ok("Department Deleted");
        }

        // Department Create
        [HttpPost]
        public IActionResult Create(CreateDepartmentDTO createDepartmentDto)
        {
            var newValue = _mapper.Map<Department>(createDepartmentDto);
            _departmentService.TCreate(newValue);
            return Ok("New Department Created");
        }
        
        //Department Update
        [HttpPut]
        public IActionResult Update(UpdateDepartmentDTO updateDepartmentDto)
        {
            var value = _mapper.Map<Department>(updateDepartmentDto);
            _departmentService.TUpdate(value);
            return Ok("Department Updated");
        }
    }
}

