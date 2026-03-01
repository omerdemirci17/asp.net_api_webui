using AutoMapper;
using API_WEBUI_1.DTO.DTOs.DepartmentDTOs;
using API_WEBUI_1.Entity.Entities;

namespace API_WEBUI_1.API.Mapping
{
    public class DepartmentMapping : Profile
    {

        public DepartmentMapping()
        {
            CreateMap<CreateDepartmentDTO, Department>().ReverseMap();
            CreateMap<UpdateDepartmentDTO, Department>().ReverseMap();
        }
    }

}
