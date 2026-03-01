using API_WEBUI_1.DTO.DTOs.ServicesDTOs;
using API_WEBUI_1.Entity.Entities;
using AutoMapper;

namespace API_WEBUI_1.API.Mapping
{
    public class ServiceMapping : Profile
    {
        public ServiceMapping()
        {
            CreateMap<CreateServiceDTO, Service>().ReverseMap();
            CreateMap<UpdateServiceDTO, Service>().ReverseMap();
        }
    }
}
