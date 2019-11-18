using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.User
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.Name)
                .HasColumnType("nvarchar(500)")
                .IsRequired();

            builder
                .Property(p => p.CPF)
                .HasColumnType("nvarchar(14)");

            builder
                .Property(p => p.Email)
                .HasColumnType("nvarchar(100)");

        }
    }
}
