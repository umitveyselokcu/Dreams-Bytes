using DreamsBytes.Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamsBytes.Data.Mappings
{
    public class ShoppingCartItemMap : BaseMapConfiguration<ShoppingCartItem> ,IEntityTypeConfiguration<ShoppingCartItem>
    {
        public override void Configure(EntityTypeBuilder<ShoppingCartItem> builder)
        {
            builder.HasKey(bc => new { bc.ProductId, bc.UserId });
            builder.HasOne(item => item.User)
                .WithMany(item => item.ShoppingCartItems)
                .HasForeignKey(item => item.UserId)
                .IsRequired();
            builder.HasOne(item => item.Product)
                .WithMany(item=>item.CartItems).HasForeignKey(x=>x.ProductId).IsRequired(); 

            builder.HasData(
                new ShoppingCartItem { Id = 1, ProductId = 1, UserId = 1, Quantity = 4 },
                new ShoppingCartItem { Id = 2, ProductId = 1, UserId = 2, Quantity = 4 }, 
                new ShoppingCartItem { Id = 3, ProductId = 2, UserId = 1, Quantity = 4 }, 
                new ShoppingCartItem { Id = 4, ProductId = 3, UserId = 1, Quantity = 4 }, 
                new ShoppingCartItem { Id = 5, ProductId = 1, UserId = 3, Quantity = 4 });
            base.Configure(builder);
        }
    }
}