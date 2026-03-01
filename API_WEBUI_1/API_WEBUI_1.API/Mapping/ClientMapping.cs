
using API_WEBUI_1.DTO.DTOs.ClientDTOs;
using API_WEBUI_1.Entity.Entities;
using AutoMapper;
namespace API_WEBUI_1.API.Mapping
{
    public class ClientMapping : Profile
    {
        public ClientMapping()
        {
            CreateMap<CreateClientDTO, Client>().ReverseMap();
            CreateMap<UpdateClientDTO, Client>().ReverseMap();
        }
    }
}
