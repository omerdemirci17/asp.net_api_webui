using AutoMapper;
using API_WEBUI_1.DTO.DTOs.EmployeeDTOs;
using API_WEBUI_1.Entity.Entities;
using API_WEBUI_1.DTO.DTOs.SocialMediaDTOs;

namespace API_WEBUI_1.API.Mapping
{
    public class EmployeeMapping : Profile
    {

        public EmployeeMapping()
        {
            CreateMap<Employee, ResultEmployeeDTO>()
    .ForMember(dest => dest.SocialMedia, opt => opt.MapFrom(src => src.SocialMedia)); // Dikkat: src'deki isim burada önemli
            CreateMap<SocialMedia, ResultSocialMediaDTO>();

            CreateMap<SocialMedia, ResultSocialMediaDTO>();

            CreateMap<CreateEmployeeDTO, Employee>().ReverseMap();
            CreateMap<UpdateEmployeeDTO, Employee>().ReverseMap();
        }
    }

}
