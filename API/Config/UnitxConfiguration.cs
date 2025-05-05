using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Config
{
    public class UnitxConfiguration : IEntityTypeConfiguration<Unitx>
    {
        public void Configure(EntityTypeBuilder<Unitx> builder)
        {
            builder.ToTable("Units");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(u => u.Details)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.Property(u => u.Rate)
                   .IsRequired()
                   .HasMaxLength(10);

            builder.Property(u => u.Area)
                   .IsRequired();

            builder.Property(u => u.Ocupancy)
                   .IsRequired();

            builder.Property(u => u.ImageUrl)
                   .IsRequired()
                   .HasMaxLength(250);

            builder.Property(u => u.Amenity)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(u => u.CreatedAt)
                   .IsRequired();

            builder.Property(u => u.UpdatedAt)
                   .IsRequired();
            builder.HasData(
                new Unitx() { Id = 1, Name = "Ziad", Details = "toomuch", Area = 200, Amenity = "too many", ImageUrl = "1.jpg", Ocupancy = 9, Rate = "5 stars", CreatedAt = DateTime.Now },

                new Unitx() { Id = 2, Name = "Nadine", Details = "toomuch", Area = 200, Amenity = "too many", ImageUrl = "2.jpg", Ocupancy = 9, Rate = "5 stars", CreatedAt = DateTime.Now },

                new Unitx() { Id = 3, Name = "Nour", Details = "toomuch", Area = 200, Amenity = "too many", ImageUrl = "3.jpg", Ocupancy = 9, Rate = "5 stars", CreatedAt = DateTime.Now },

                new Unitx() { Id = 4, Name = "Amr", Details = "toomuch", Area = 200, Amenity = "too many", ImageUrl = "4.jpg", Ocupancy = 9, Rate = "5 stars", CreatedAt = DateTime.Now },

                new Unitx() { Id = 5, Name = "Darine", Details = "toomuch", Area = 200, Amenity = "too many", ImageUrl = "5.jpg", Ocupancy = 9, Rate = "5 stars", CreatedAt = DateTime.Now });
        }
    }
}
