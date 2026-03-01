using API_WEBUI_1.DTO.DTOs.AboutDtos;
using API_WEBUI_1.Entity.Entities;
using AutoMapper;

namespace API_WEBUI_1.API.Mapping
{
    public class AboutMapping : Profile
    {
        public AboutMapping()
        {
            CreateMap<CreateAboutDTO, About>().ReverseMap();
            CreateMap<UpdateAboutDto, About>().ReverseMap();
        }
    }
}
