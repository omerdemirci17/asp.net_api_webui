using API_WEBUI_1.DTO.DTOs.MessageDtos;
using API_WEBUI_1.Entity.Entities;
using AutoMapper;

namespace API_WEBUI_1.API.Mapping
{
    public class MessageMapping : Profile
    {
        public MessageMapping()
        {
            CreateMap<CreateMessageDto, Message>().ReverseMap();
            CreateMap<UpdateMessageDto, Message>().ReverseMap();
        }
    }
}
