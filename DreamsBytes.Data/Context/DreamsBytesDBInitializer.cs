using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DreamsBytes.Data.UnitOfWork;
using DreamsBytes.Core.Entites;
using DreamsBytes.Data.Repositories;

namespace DreamsBytes.Data.Context
{
    //public class DreamsBytesDBInitializer: DropCreateDatabaseAlways<EFDataContext>
    //{
    //}

    public static class DatabaseSeedInitializer
    {
        public static IHost SeedDb(this IHost host)
        {
            //using (IUnitOfWork unitOfWork = new UnitOfWork.UnitOfWork())
            //{
               
            //        try
            //        {
            //            DataSeeder.Seed(unitOfWork);
            //        }
            //        catch (Exception ex)
            //        {
            //            Console.WriteLine(ex);
            //            throw;
            //        }
                
            //}

            return host;
        }
    }

    public class DataSeeder
    {
        public static void Seed(IUnitOfWork unitOfWork)
        {

            //if (!unitOfWork.Users.Find    )
            //{

            //}

           



            //var dsa = unitOfWork.GetRepository<ProductType>();
            //var a = dsa.GetById(1);
            //a.Name = "Kalemi";
            //unitOfWork.Complete();
            //a.Name = "Kaalemi";
            //unitOfWork.Complete();
            //a.Name = "Kaalemia";
            ////var ddd = ""; 







            //if (!context..Countries.Any())
            //{
            //    var countries = new List<Country>
            //    {
            //        new Country { Name = "Afghanistan" },
            //        new Country { Name = "Albania" },
            //        new Country { Name = "Algeria" },
            //        new Country { Name = "Andorra" },
            //        new Country { Name = "Angola" },
            //        new Country { Name = "Antigua and Barbuda" },
            //        new Country { Name = "Argentina" },
            //        new Country { Name = "Armenia" },
            //        new Country { Name = "Aruba" },
            //        new Country { Name = "Australia" },
            //        new Country { Name = "Austria" },
            //        new Country { Name = "Azerbaijan" },
            //        ...
            //    };
            //    context.AddRange(countries);
            //    context.SaveChanges();
            
        }
    }
}
