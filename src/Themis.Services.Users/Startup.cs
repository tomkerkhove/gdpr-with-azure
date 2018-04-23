﻿using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Themis.Services.Users
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
            var xmlDocumentationPath = GetXmlDocumentationPath(services);
            var openApiInformation = new Info
            {
                Contact = new Contact
                {
                    Name = "Tom Kerkhove",
                    Url = "https://blog.tomkerkhove.be"
                },
                Title = "Themis - Users Service v1",
                Description = "Collection of APIs to get all users",
                Version = "v1",
                License = new License
                {
                    Name = "MIT",
                    Url = "https://github.com/tomkerkhove/promitor/LICENSE"
                }
            };

            services.AddMvc();
            services.AddSwaggerGen(swaggerGenerationOptions =>
            {
                swaggerGenerationOptions.SwaggerDoc($"v1", openApiInformation);
                swaggerGenerationOptions.DescribeAllEnumsAsStrings();

                if (string.IsNullOrEmpty(xmlDocumentationPath) == false)
                {
                    swaggerGenerationOptions.IncludeXmlComments(xmlDocumentationPath);
                }
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(swaggerUiOptions =>
            {
                swaggerUiOptions.SwaggerEndpoint("/swagger/v1/swagger.json", "Users Service");
                swaggerUiOptions.DisplayOperationId();
                swaggerUiOptions.EnableDeepLinking();
                swaggerUiOptions.DocumentTitle = "Users Service";
                swaggerUiOptions.DocExpansion(DocExpansion.List);
                swaggerUiOptions.DisplayRequestDuration();
                swaggerUiOptions.EnableFilter();
            });
        }

        private static string GetXmlDocumentationPath(IServiceCollection services)
        {
            var hostingEnvironment =
                services.FirstOrDefault(service => service.ServiceType == typeof(IHostingEnvironment));
            if (hostingEnvironment == null)
            {
                return string.Empty;
            }

            var contentRootPath = ((IHostingEnvironment) hostingEnvironment.ImplementationInstance).ContentRootPath;
            var xmlDocumentationPath = $"{contentRootPath}\\Docs\\Open-Api.xml";

            return File.Exists(xmlDocumentationPath) ? xmlDocumentationPath : string.Empty;
        }
    }
}