using API_WEBUI_1.DTO.DTOs.BlogDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_WEBUI_1.DTO.DTOs.BlogCategoryDtos
{
    public class CreateBlogCategoryDto
    {
        public int BlogCategoryId { get; set; }
        public string Name { get; set; }
        public List<ResultBlogDto> Blogs { get; set; } = new();

    }
}
