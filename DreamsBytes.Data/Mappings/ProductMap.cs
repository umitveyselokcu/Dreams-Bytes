using DreamsBytes.Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DreamsBytes.Data.Mappings
{
    public class ProductMap : BaseMapConfiguration<Product>, IEntityTypeConfiguration<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => new { x.ProductTypeId });
            builder.Ignore(x => x.CartItems);
            builder.Property(product => product.Price).HasColumnType("decimal(18, 2)");
            builder.HasOne(product => product.ProductType).WithMany(x => x.Products).HasForeignKey(x => x.ProductTypeId).IsRequired();

            builder.HasData
               (
                   new Product
                   {
                       Id = 1,
                       Name = "Kalem",
                       Price = 12.0m,
                       Quantity = 177,
                       ProductTypeId = 1
                   },
                   new Product
                   {
                       Id = 2,
                       Name = "Silgi",
                       Price = 2.0m,
                       Quantity = 173,
                       ProductTypeId = 1
                   },
                   new Product
                   {
                       Id = 3,
                       Name = "Tebeşir",
                       Price = 7.0m,
                       Quantity = 174,
                       ProductTypeId = 1
                   },
                    new Product
                    {
                        Id = 4,
                        Name = "Gta",
                        Price = 12.0m,
                        Quantity = 177,
                        ProductTypeId = 2
                    },
                   new Product
                   {
                       Id = 5,
                       Name = "Dark Souls",
                       Price = 2.0m,
                       Quantity = 173,
                       ProductTypeId = 2
                   },
                   new Product
                   {
                       Id = 6,
                       Name = "Metallica Black",
                       Price = 7.0m,
                       Quantity = 174,
                       ProductTypeId = 3
                   }
               );
            base.Configure(builder);
        }
    }
}
