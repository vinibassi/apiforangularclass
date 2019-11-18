using Microsoft.EntityFrameworkCore;
using DAL.Photo;
using DAL.User;

namespace DAL
{
    public class ApiForAngularContext : DbContext
    {
        public DbSet<DAL.Photo.Photo> Photos { get; set; }
        public DbSet<DAL.User.User> Users { get; set; }

        public ApiForAngularContext(DbContextOptions<ApiForAngularContext> options)
            : base(options)
        {
            //irá criar o banco e a estrutura de tabelas necessárias
            this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder
                .ApplyConfiguration(new PhotoConfiguration())
                .ApplyConfiguration(new UserConfiguration());
        }
    }
}
