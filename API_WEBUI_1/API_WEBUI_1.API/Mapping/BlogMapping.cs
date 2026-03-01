using API_WEBUI_1.DTO.DTOs.BlogDtos;
using API_WEBUI_1.Entity.Entities;
using AutoMapper;

namespace API_WEBUI_1.API.Mapping
{
    public class BlogMapping : Profile
    {
        public BlogMapping()
        {
            CreateMap<CreateBlogDto, Blog>().ReverseMap();
            CreateMap<UpdateBlogDto, Blog>().ReverseMap();
            CreateMap<Blog, ResultBlogDto>()
                .ForMember(d => d.CategoryName,
                           opt => opt.MapFrom(src => src.BlogCategory.Name));
        }
    }
}
