using API_WEBUI_1.WebUI.DTOs.BlogCategoryDTOs;
using API_WEBUI_1.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_WEBUI_1.WebUI.DTOs.BlogDTOs
{
    public class ResultBlogDto
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public DateTime BlogDate { get; set; }
        public int BlogCategoryId { get; set; }
        public ResultBlogCategoryDto? BlogCategory { get; set; }
        public string CategoryName { get; set; }
    }
}
