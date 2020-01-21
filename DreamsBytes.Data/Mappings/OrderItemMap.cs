using DreamsBytes.Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamsBytes.Data.Mappings
{
    public class OrderItemMap :BaseMapConfiguration<OrderItem>, IEntityTypeConfiguration<OrderItem> 
    {     
        public override void Configure(EntityTypeBuilder<OrderItem> builder)          
        {           
            builder.Property(orderItem => orderItem.UnitPrice).HasColumnType("decimal(18, 2)");
            
            builder.HasOne(order => order.Order)
                .WithMany(x=>x.OrderItems)
                .HasForeignKey(order => order.OrderId);
            builder.HasData(
                new OrderItem { Id = 1, ProductId = 1, OrderId = 1, Quantity = 7, Name = "Kalem", UnitPrice = 12.0m },
                new OrderItem { Id = 2, ProductId = 1, OrderId = 2, Quantity = 4, Name = "Kalem", UnitPrice = 12.0m },
                new OrderItem { Id = 3, ProductId = 2, OrderId = 1, Quantity = 3, Name = "Silgi", UnitPrice = 2.0m, },
                new OrderItem { Id = 4, ProductId = 3, OrderId = 1, Quantity = 1, Name = "Tebeşir", UnitPrice = 7.0m }
                );
            base.Configure(builder);
                
        }
    }
}
