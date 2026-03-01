using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_WEBUI_1.Entity.Entities
{
    public class BlogCategory
    {
        public int BlogCategoryID { get; set; }
        public string Name { get; set; }
        public List<Blog> Blogs { get; set; } 
    }
}
