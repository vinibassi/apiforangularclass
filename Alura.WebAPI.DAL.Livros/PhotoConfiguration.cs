using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DALPhotos
{
    internal class PhotoConfiguration : IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.Desc)
                .HasColumnType("nvarchar(50)")
                .IsRequired();

            builder
                .Property(p => p.ImageUrl)
                .HasColumnType("nvarchar(1000)");

        }
    }
}