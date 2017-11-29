using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MicroServiceExec.RabbitMQService;
using Autofac;

namespace Webapi
{
    public class Startup
    {
        private static IContainer Container { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            IocInit();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }

        private static void IocInit()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<RMQConnection>().As<IRMQConnection>();
            builder.RegisterType<RMQOperator>().As<IRMQOperator>();

            Container = builder.Build();

        }
    }
}
