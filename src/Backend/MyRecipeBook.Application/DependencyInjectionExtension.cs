using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using MyRecipeBook.Application.AutoMapper;
using MyRecipeBook.Application.UseCases.User.Register;
using MyRecipeBook.Domain.Repositories.User;
using MyRecipeBook.Infrastructure.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipeBook.Application
{
    public static class DependencyInjectionExtension
    {
        public static void AddAplicationDependencyInjection(this IServiceCollection services)
        {
            AddRepositories(services);
            AddUseCases(services);
            AddAutoMapper(services);
        }

        public static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IUserReadOnlyRepository, UserRepository>();
            services.AddScoped<IUserWriteOnlyRepository, UserRepository>();
        }

        public static void AddUseCases(IServiceCollection services)
        {
            services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
        }
        public static void AddAutoMapper(IServiceCollection services)
        {
            services.AddScoped(option => new MapperConfiguration(options =>
            {
                options.AddProfile(new AutoMapping());
            }).CreateMapper());
        }
    }
}
