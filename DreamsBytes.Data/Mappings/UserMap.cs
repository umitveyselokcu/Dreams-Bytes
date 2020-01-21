using DreamsBytes.Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DreamsBytes.Data.Mappings
{
    public class UserMap : BaseMapConfiguration<User>, IEntityTypeConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(user => user.Username).HasMaxLength(1000);
            builder.Property(user => user.Email).HasMaxLength(1000);

            builder.HasMany(user => user.ShoppingCartItems)
                .WithOne()
                .HasForeignKey(user => user.UserId);
            builder.HasOne(user => user.UserPassword)
                .WithOne(password => password.User);
            builder
            .HasMany<ShoppingCartItem>(g => g.ShoppingCartItems)
            .WithOne()
            .HasForeignKey(s => s.UserId);
            builder.Ignore(user => user.UserPassword);
            builder.HasData
                (
                    new User
                    {
                        Id = 1,
                        Email = "admin@admin.com",
                        Username = "Admin1",
                        LastName = "Soyisim",
                        FirstName = "İsim",
                        PhoneNumber = "0000000000",
                        UserRoleId = UserRole.Admin


                    },
                    new User
                    {
                        Id = 2,
                        Email = "2admin@admin.com",
                        Username = "2Admin",
                        LastName = "2AdminLast",
                        FirstName = "2AdminFirst",
                        PhoneNumber = "0000000000",
                        UserRoleId = UserRole.User
                    },
                    new User
                    {
                        Id = 3,
                        Email = "3admin@admin.com",
                        Username = "3Admin",
                        LastName = "3AdminLast",
                        FirstName = "3AdminFirst",
                        PhoneNumber = "0000000000",
                        UserRoleId = UserRole.User
                    }
                );


            base.Configure(builder);

        }
    }
}