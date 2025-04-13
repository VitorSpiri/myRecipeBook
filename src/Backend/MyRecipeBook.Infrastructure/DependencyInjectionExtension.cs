using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyRecipeBook.Domain.Repositories.User;
using MyRecipeBook.Infrastructure.DataAccess;
using MyRecipeBook.Infrastructure.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipeBook.Infrastructure
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrastructureDependencyInjection(this IServiceCollection services)
        {
            AddRepositories(services);
            AddDbContext(services);
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IUserReadOnlyRepository, UserRepository>();
            services.AddScoped<IUserWriteOnlyRepository, UserRepository>();
        }

        private static void AddDbContext(IServiceCollection services)
        {
            var connectionString = "User ID=root;Password=n12!;Host=localhost;Port=5432;Database=myRecipeBook;Pooling=true;Min Pool Size=0;Max Pool Size=100;Connection Lifetime=0;";

            services.AddDbContext<MyRecipeBookDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });
        }
    }
}
