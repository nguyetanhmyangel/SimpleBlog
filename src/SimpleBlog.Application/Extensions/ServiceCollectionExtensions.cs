//using FluentValidation;
//using MediatR;
//using Microsoft.Extensions.DependencyInjection;
//using System.Reflection;

using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace SimpleBlog.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Config Add AutoMapper,FluentValidation Application project
        /// </summary>
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            //services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}