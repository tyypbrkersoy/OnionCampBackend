using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionCamp.Application
{
    public static class ServiceRegistration
    {
        public static void AddAplicationService(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ServiceRegistration));
            services.AddHttpClient();
        }
    }
}
