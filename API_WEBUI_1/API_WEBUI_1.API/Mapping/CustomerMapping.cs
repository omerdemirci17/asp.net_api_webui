using AutoMapper;
using API_WEBUI_1.DTO.DTOs.CustomerDTOs;
using API_WEBUI_1.Entity.Entities;

namespace API_WEBUI_1.API.Mapping
{
    public class CustomerMapping : Profile
    {
        public CustomerMapping()
        {
            CreateMap<CreateCustomerDTO, Customer>().ReverseMap();
            CreateMap<UpdateCustomerDTO, Customer>().ReverseMap();
        }
    }

}
