using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.Entities;

namespace WebApi.Database.Map
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x =>  x.Id);
            builder.HasIndex(x => x.Id);
            builder.ToTable("products");

            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Title).HasColumnName("game_title");
            builder.Property(x => x.Price).HasColumnName("game_price");
            builder.Property(x => x.Genre).HasColumnName("game_genre");
            builder.Property(x => x.Language).HasColumnName("game_language");
            builder.Property(x => x.Description).HasColumnName("game_description");
        }
    }
}
