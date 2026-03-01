using API_WEBUI_1.Entity.Entities;
using API_WEBUI_1.WebUI.DTOs.RoleDTOs;
using AutoMapper;

namespace API_WEBUI_1.WebUI.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<AppRole, CreateRoleDTO>().ReverseMap();
            CreateMap<AppRole, ResultRoleDTO>().ReverseMap();
            CreateMap<AppRole, UpdateRoleDTO>().ReverseMap();
        }
    }
}
