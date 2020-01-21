using DreamsBytes.Core.Entites;
using DreamsBytes.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamsBytes.Services
{
    public interface IUserService
    {
        public (bool verified, UserViewModel user) Login(string Email, string Password);
    }
}
