using API_WEBUI_1.WebUI.DTOs.BlogDTOs;
using API_WEBUI_1.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_WEBUI_1.WebUI.DTOs.BlogCategoryDTOs
{
    public class UpdateBlogCategoryDto
    {
        public int BlogCategoryId { get; set; }
        public string Name { get; set; }
        public List<ResultBlogDto> Blogs { get; set; } = new();

    }
}
