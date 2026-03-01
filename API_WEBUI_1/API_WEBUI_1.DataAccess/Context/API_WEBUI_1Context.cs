using API_WEBUI_1.Entity.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace API_WEBUI_1.DataAccess.Context
{
    public class API_WEBUI_1Context : IdentityDbContext<AppUser,AppRole,int>
    {
        public API_WEBUI_1Context(DbContextOptions<API_WEBUI_1Context> options) : base(options)
        {
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogCategory> BlogCategories { get; set; } 
        public DbSet<Client> Clients { get; set; }
        public DbSet<FeaturedServices> FeaturedServices { get; set; } 
        public DbSet<ServiceCategory> ServiceCategories { get; set; } 
        public DbSet<Subscriber> Subscribers { get; set; } 
        public DbSet<Service> Services { get; set; } 
        public DbSet<Contact> Contacts { get; set; }         //Contacts table
        public DbSet<Message> Messages { get; set; }         //Messages Table
        public DbSet<SocialMedia> SocialMedias { get; set; } //Social Medias table
        public DbSet<Testimonial> Testimonials { get; set; } // Testimonials table
        public DbSet<Employee> Employees { get; set; }       // Employees table
        public DbSet<Customer> Customers { get; set; }       // Customers table
        public DbSet<Department> Departments { get; set; }   // Departments table
    }
}



