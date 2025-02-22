﻿using CleanArquitecture.Application.Behaviours;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace CleanArquitecture.Application
{
   public static class ApplicationServiceRegistration
   {
      
      public static IServiceCollection AddApplicationServices(this IServiceCollection services)
      {
         services.AddAutoMapper(Assembly.GetExecutingAssembly());
         services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
         //services.AddMediatR(Assembly.GetExecutingAssembly());

         services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
         
         services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
         services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviuor<,>));

         return services;
      }

   }

}
