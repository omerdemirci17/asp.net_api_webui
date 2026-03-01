using API_WEBUI_1.Business.Abstract;
using API_WEBUI_1.DTO.DTOs.AboutDtos;
using API_WEBUI_1.Entity.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API_WEBUI_1.API.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class AboutController(IGenericService<About> _aboutService, IMapper _mapper) : ControllerBase
        {
            // Get all
            [HttpGet]
            public IActionResult Get()
            {
                var values = _aboutService.TGetList();
                return Ok(values);
            }

            // Get by ID
            [HttpGet("{id}")]
            public IActionResult GetById(int id)
            {
                var value = _aboutService.TGetById(id);
                return Ok(value);
            }

            // Delete
            [HttpDelete("{id}")]
            public IActionResult DeleteById(int id)
            {
                _aboutService.TDelete(id);
                return Ok("About Deleted");
            }

            // Create
            [HttpPost]
            public IActionResult Create([FromBody] CreateAboutDTO createAboutDto)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var newValue = _mapper.Map<About>(createAboutDto);
                _aboutService.TCreate(newValue);
                return Ok("New About Created");
            }

            // Update
            [HttpPut]
            public IActionResult Update(UpdateAboutDto updateAboutDto)
            {
                var value = _mapper.Map<About>(updateAboutDto);
                _aboutService.TUpdate(value);
                return Ok("About Updated");
            }
        }
    }

