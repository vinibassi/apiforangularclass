using Microsoft.EntityFrameworkCore;

namespace DALPhotos
{
    public class PhotoContext : DbContext
    {
        public DbSet<Photo> Photos { get; set; }

        public PhotoContext(DbContextOptions<PhotoContext> options)
            : base(options)
        {
            //irá criar o banco e a estrutura de tabelas necessárias
            this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new PhotoConfiguration());
        }
    }
}
