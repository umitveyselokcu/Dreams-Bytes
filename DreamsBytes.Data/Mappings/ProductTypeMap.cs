using DreamsBytes.Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DreamsBytes.Data.Mappings
{






    public class ProductTypeMap : BaseMapConfiguration<ProductType>, IEntityTypeConfiguration<ProductType>
    {
        public override void Configure(EntityTypeBuilder<ProductType> builder)
        {

            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Products).WithOne(x=>x.ProductType).HasForeignKey(x=>x.ProductTypeId);
            builder.Ignore(x => x.Products);
            builder.HasData
               (
                   new ProductType
                   {
                       Id = 1,
                       Name = "Kırtasite",
                   },
                   new ProductType
                   {
                       Id = 2,
                       Name = "Oyun",

                   },
                   new ProductType
                   {
                       Id = 3,
                       Name = "Müzik",

                   }
               );
            base.Configure(builder);
        }
    }
}