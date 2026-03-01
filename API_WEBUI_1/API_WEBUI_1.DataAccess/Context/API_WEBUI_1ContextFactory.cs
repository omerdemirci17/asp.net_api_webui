using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace API_WEBUI_1.DataAccess.Context
{
    public class API_WEBUI_1ContextFactory : IDesignTimeDbContextFactory<API_WEBUI_1Context>
    {
        public API_WEBUI_1Context CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<API_WEBUI_1Context>();
            optionsBuilder.UseSqlServer("Server=OMER-DEMIRCI17;Database=API_WEBUI_1Db;Integrated Security=True;TrustServerCertificate=True");

            return new API_WEBUI_1Context(optionsBuilder.Options);
        }
    }
}



