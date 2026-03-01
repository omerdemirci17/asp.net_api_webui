using API_WEBUI_1.DTO.DTOs.FeaturedServicesDTO;
using API_WEBUI_1.Entity.Entities;
using AutoMapper;

namespace API_WEBUI_1.API.Mapping
{
    public class FeaturedServicesMapping : Profile
    {
        public FeaturedServicesMapping()
        {
            CreateMap<CreateFeaturedServicesDTO, FeaturedServices>().ReverseMap();
            CreateMap<UpdateFeaturedServicesDTO, FeaturedServices>().ReverseMap();
        }
    }
}
