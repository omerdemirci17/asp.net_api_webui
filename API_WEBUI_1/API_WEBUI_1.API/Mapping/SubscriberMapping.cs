using API_WEBUI_1.DTO.DTOs.SubscriberDtos;
using API_WEBUI_1.Entity.Entities;
using AutoMapper;

namespace API_WEBUI_1.API.Mapping
{
    public class SubscriberMapping : Profile
    {
        public SubscriberMapping()
        {
            CreateMap<CreateSubscriberDto, Subscriber>().ReverseMap();
            CreateMap<UpdateSubscriberDto, Subscriber>().ReverseMap();
        }
    }
}
