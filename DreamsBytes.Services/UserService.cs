using AutoMapper;
using DreamsBytes.Core.Entites;
using DreamsBytes.Data.UnitOfWork;
using DreamsBytes.Services.Helpers;
using DreamsBytes.Services.Models;
using System.Linq;

namespace DreamsBytes.Services
{
    public class UserService : IUserService
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IPasswordHasher passwordHasher, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
        }

        public (bool verified, UserViewModel user) Login(string Email, string Password)
        {
            UserViewModel userModel = new UserViewModel();

            Data.Repositories.IRepository<User> userRepository = _unitOfWork.GetRepository<User>();
            Data.Repositories.IRepository<UserPassword> passRepository = _unitOfWork.GetRepository<UserPassword>();

            System.Collections.Generic.IEnumerable<User> user = userRepository.Find(x => x.Email == Email);
            if (!user.Any())
            {
                return (false, userModel);
            }

            userModel = _mapper.Map<User, UserViewModel>(user.FirstOrDefault());
            System.Collections.Generic.IEnumerable<UserPassword> password = passRepository.Find(x => x.UserId == user.FirstOrDefault().Id);
            if (!password.Any())
            {
                return (false, userModel);
            }

            (bool Verified, bool NeedsUpgrade) validation = _passwordHasher.Check(password.FirstOrDefault().Password, Password);
            if (!validation.Verified)
            {
                return (false, userModel);
            }

            return (true, userModel);
        }
    }
}
