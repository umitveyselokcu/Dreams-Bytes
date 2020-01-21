using DreamsBytes.Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace DreamsBytes.Data.Mappings
{
    public class OrderMap : BaseMapConfiguration<Order>, IEntityTypeConfiguration<Order>
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(order => order.OrderTotal).HasColumnType("decimal(18, 2)");
            builder.HasOne(order => order.User)
                    .WithMany(user=>user.Orders)
                    .HasForeignKey(order => order.UserId)
                    .IsRequired();
            builder.HasMany(order => order.OrderItems)
                    .WithOne(order=>order.Order)
                    .HasForeignKey(order=>order.OrderId);
            builder.HasData(
                new Order { Id = 1, UserId = 1 ,OrderTotal= 97.0m},
                new Order { Id = 2, UserId = 1, OrderTotal = 12.0m }
                );
            base.Configure(builder);           
        }
    }
}



