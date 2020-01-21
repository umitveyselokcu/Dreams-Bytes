using System;

namespace DreamsBytes.Core.Entites
{
    public class UserPassword : BaseEntity
    {
        public int UserId { get; set; }

        public string Password { get; set; }

        public string PasswordSalt { get; set; }

        public virtual User User { get; set; }

    }
}
