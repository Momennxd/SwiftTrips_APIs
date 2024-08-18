﻿using Core_Layer.AppDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core_Layer.AppDbContext;
namespace Core_Layer
{
    /// <summary>
    /// Created to use Dependency Inversion Principle
    /// </summary>
    public static class clsService
    {
        public static IDbContextFactory<AppDbContext.AppDbContext>? contextFactory { get; }

        public static AppDbContext.AppDbContext Context { get; }

        static clsService()
        {
            
            string connectionString = //Needs more security
           "Server = . ; Database = SwiftTripsDB; User Id=sa; Password=sa123456; TrustServerCertificate=true";

            ServiceCollection service = new ServiceCollection();
            service.AddDbContextFactory<AppDbContext.AppDbContext>(options => options.UseSqlServer(connectionString));
            IServiceProvider serviceProvider = service.BuildServiceProvider();
            contextFactory = serviceProvider.GetService<IDbContextFactory<AppDbContext.AppDbContext>>();




            Context = clsService.contextFactory!.CreateDbContext();
        }
    }
}
