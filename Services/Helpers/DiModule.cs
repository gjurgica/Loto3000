using DataAccess;
using DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Helpers
{
    public static class DiModule
    {
        public static IServiceCollection RegisterModule(
            IServiceCollection services, string connectionString)
        {
            services.AddTransient<IRepository<UserDbo>, UserRepository>();
            services.AddTransient<IRepository<WinnerDbo>, WinnerRepository>();
            services.AddTransient<IRepository<SessionDbo>, SessionRepository>();
            services.AddTransient<IRepository<TicketDbo>, TicketRepository>();
            services.AddDbContext<LotoAppDbContext>(x =>
            x.UseSqlServer(connectionString));

            return services;
        }
    }
}
