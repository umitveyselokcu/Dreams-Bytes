using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Text.Json;

namespace DreamsBytes.Data.Context
{
    public static class RefreshDatabaseManager
    {
       // string shouldDbRefresh = "";

       // public static IServiceCollection InitiateDb(this IServiceCollection services,
       //IConfiguration configuration)
       // {
       //     shouldDbRefresh = configuration["AppSettings:SHOULD_DB_REFRESH"];

       //     return services.;
       // }

        public static IHost RefreshDatabase(this IHost host)
        {

            using (var scope = host.Services.CreateScope())
            {
                using (var appContext = scope.ServiceProvider.GetRequiredService<EFDataContext>())
                {
                    try
                    {
                        var jsonBytes = File.ReadAllBytes("appsettings.json");
                        using var jsonDoc = JsonDocument.Parse(jsonBytes);
                        var root = jsonDoc.RootElement;

                        var shouldResfresh = root.GetProperty("AppSettings").GetProperty("SHOULD_DB_REFRESH").GetString();
                        
                        if (shouldResfresh == "true")
                        {
                            appContext.Database.EnsureDeleted();
                            appContext.Database.EnsureCreated();
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        throw;
                    }
                }
            }

            return host;
        }


    }
}
