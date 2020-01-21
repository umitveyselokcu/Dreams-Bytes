using NUnit.Framework;

using DreamsBytes.Data.Repositories;
using DreamsBytes.Data.Context;
using DreamsBytes.Data.UnitOfWork;
using DreamsBytes.Core.Entites;
using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.Configuration;

namespace DreamsBytes.NUnitTestProject
{
    public class Tests
    {
        //private EFDataContext _dbContext;

        //private IUnitOfWork _uow;
        //private IRepository<User> _userRepository;
        //private IRepository<Product> _productRepository;
        //private IRepository<Order> _orderRepository;
        //private IRepository<ShoppingCartItem> _shoppingCartItemRepository;
        [SetUp]
        public void Setup()
        {

          
            //var optionas = new DbContextOptions();
            //       _dbContext = new EFDataContext();

            // EFBlogContext'i kullanıyor olduğumuz için EFUnitOfWork'den türeterek constructor'ına
            // ilgili context'i constructor injection yöntemi ile inject ediyoruz.
            //      _uow = new UnitOfWork<EFDataContext>();
            //_userRepository = new Repository<User>();
            //_productRepository = new Repository<Product>(_dbContext);
            //_orderRepository = new Repository<Order>(_dbContext);
            //_shoppingCartItemRepository = new Repository<ShoppingCartItem>(_dbContext);

        }

        //[Test]
        //public void Test1()
        //{
        //    Assert.Pass();
        //}
        //[Test]
        //public void GetUser()
        //{
        //    User user = _userRepository.GetById(1);

        //    Assert.IsNotNull(user);
        //}

        //[Test]
        //public void UpdateUser()
        //{
        //    User user = _userRepository.GetById(1);

        //    user.FirstName = "Mehmet";

        //    _userRepository.Update(user);
        //    int process = _uow.SaveChanges();

        //    Assert.AreNotEqual(-1, process);
        //}

        //[Test]
        //public void DeleteUser()
        //{
        //    User user = _userRepository.GetById(1);

        //    _userRepository.Delete(user);
        //    int process = _uow.SaveChanges();

        //    Assert.AreNotEqual(-1, process);
        //}
    }

    public abstract class BaseTest
    {
        //protected BaseTest()
        //{
        //    var builder = new ConfigurationBuilder()
        //        .AddJsonFile("appsettings.json");
        //    Configuration = builder.Build();
        //}
        //protected IConfiguration Configuration { get; private set; }
    }
}