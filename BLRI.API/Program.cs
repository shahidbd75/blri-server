﻿using BLRI.DAL.Repositories.Core;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using BLRI.DAL.SeedData;

namespace BLRI.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var host = CreateWebHostBuilder(args).Build();

            //    using (var scope = host.Services.CreateScope())
            //    {
            //        var services = scope.ServiceProvider;
            //        try
            //        {
            //            var context = services.GetRequiredService<ApplicationDbContext>();
            //            DbInitializer.Initialize(context);
            //        }
            //        catch (Exception ex)
            //        {
            //            var logger = services.GetRequiredService<ILogger<Program>>();
            //            logger.LogError(ex, "An error occurred while seeding the database.");
            //        }
            //    }

             
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
