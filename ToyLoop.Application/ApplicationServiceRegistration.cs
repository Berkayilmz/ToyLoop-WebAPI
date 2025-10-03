using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using ToyLoop.Application.Features.Users.Mappings;

namespace ToyLoop.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // MediatR → tüm handler'ları bu assembly’den yükler
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            // FluentValidation → tüm validator’ları bulur
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            // AutoMapper 15 → bu assembly içindeki Profile’ları yüklerc
            services.AddAutoMapper(cfg => { }, Assembly.GetExecutingAssembly());

            return services;
        }
    }
}