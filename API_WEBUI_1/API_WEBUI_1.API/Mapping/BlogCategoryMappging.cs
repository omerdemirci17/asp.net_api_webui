using API_WEBUI_1.DTO.DTOs.BlogCategoryDtos;
using API_WEBUI_1.Entity.Entities;
using AutoMapper;

namespace API_WEBUI_1.API.Mapping
{
    public class BlogCategoryMappging : Profile
    {
        public BlogCategoryMappging()
        {
            CreateMap<CreateBlogCategoryDto, BlogCategory>().ReverseMap();
            CreateMap<UpdateBlogCategoryDto, BlogCategory>().ReverseMap();
        }
    }
}
