using DreamsBytes.Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DreamsBytes.Data.Mappings
{
    public class UserPasswordMap : BaseMapConfiguration<UserPassword>, IEntityTypeConfiguration<UserPassword>
    {
        public override void Configure(EntityTypeBuilder<UserPassword> builder)
        {
            base.Configure(builder);
            builder.HasKey(bc => new { bc.UserId});
            builder.HasOne(password => password.User)
                 .WithOne(user => user.UserPassword);
                 

            builder.HasData
               (
                   new UserPassword
                   {
                       Id = 1,
                       Password ="10000.HHvXf7N/Ve58shno8n5oPQ==.2eyBdGP/UBTtAgw6pOrj+Ha6m1a4vT7zhnZ7TkWPJUY=",
                       PasswordSalt = "tuz",
                       UserId = 1,
                   },
                    new UserPassword
                    {
                        Id = 2,
                        Password = "10000.HHvXf7N/Ve58shno8n5oPQ==.2eyBdGP/UBTtAgw6pOrj+Ha6m1a4vT7zhnZ7TkWPJUY=",
                        PasswordSalt = "tuz",
                        UserId = 2,
                    }, new UserPassword
                    {
                        Id = 3,
                        Password = "10000.HHvXf7N/Ve58shno8n5oPQ==.2eyBdGP/UBTtAgw6pOrj+Ha6m1a4vT7zhnZ7TkWPJUY=",
                        PasswordSalt = "tuz",
                        UserId = 3,
                    }
               );
        }
    }
}
