using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace API.Extensions
{
    public static class MediatRSetup
    {
        public static void ConfigureMediatR(this IServiceCollection services)
        {
            var assembly = AppDomain.CurrentDomain.Load("App");
            services.AddMediatR(assembly);

            services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);
        }
    }
}
