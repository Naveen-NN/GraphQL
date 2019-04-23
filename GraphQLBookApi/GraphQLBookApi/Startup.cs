using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using GraphQL;
using GraphQL.Server;
using GraphQLBookApi.GraphQL.Schemas;
using GraphQL.Server.Ui.Playground;
using GraphQLBookApi.Repository;  

using Microsoft.AspNetCore.Http;

namespace GraphQLBookApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSingleton<BookRepository>();
            services.AddSingleton<AuthorRepository>();

            services.AddScoped<IDependencyResolver>(x => new FuncDependencyResolver(x.GetRequiredService));
            services.AddScoped<BookSchema>();
            services.AddGraphQL(x =>
            {
                x.ExposeExceptions = true;
            })
           .AddGraphTypes(ServiceLifetime.Scoped)
           .AddUserContextBuilder(httpContext => httpContext.User)
           .AddDataLoader();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseGraphQL<BookSchema>();
            var options = new GraphQLPlaygroundOptions();
            app.UseGraphQLPlayground(options);
            app.UseMvc();
        }
    }
}
