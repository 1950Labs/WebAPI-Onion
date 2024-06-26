﻿using System.Net.Mime;
using System.Runtime.Serialization;
using System.Net.Security;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Application.Beheaviours;

namespace Application
{
    public static class ServiceExtensions
    {
        /*
         This extension method allows you to configure the references, decoupling from the presentation layer
        */
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            //register automatic mappings in this assembly
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            //made validators in this assembly
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            //to implement pattern mediatR
            services.AddMediatR(Assembly.GetExecutingAssembly());

            //to apply validations in the pipeline
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        }
    }
}
