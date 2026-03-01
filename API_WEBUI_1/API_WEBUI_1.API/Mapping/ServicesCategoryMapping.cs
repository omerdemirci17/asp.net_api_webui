using API_WEBUI_1.DTO.DTOs.ServicesCategoryDTO;
using API_WEBUI_1.Entity.Entities;
using AutoMapper;

namespace API_WEBUI_1.API.Mapping
{
    public class ServicesCategoryMapping : Profile
    {
        public ServicesCategoryMapping()
        {
            CreateMap<CreateServicesCategoryDTO, ServiceCategory>().ReverseMap();
            CreateMap<UpdateServicesCategoryDTO, ServiceCategory>().ReverseMap();
        }
    }
}
