using FluentValidation;
using FluentValidation.AspNetCore;
using LMS.Application.Courses;
using LMS.Domain.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            
            services.AddScoped<ICoursesService, CoursesService>();
            services.AddAutoMapper(typeof(ServiceCollectionExtensions).Assembly);
            services.AddValidatorsFromAssembly(typeof(ServiceCollectionExtensions).Assembly)
                .AddFluentValidationAutoValidation();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceCollectionExtensions).Assembly));
        }
    }
}
