using System.Text.Json.Serialization;
using CodeChallengeBootstrap;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Endpoints
{
    public class Startup
    {
        private const string TitleApi = "MT Code Challenge Api .NET 7";
        private const string VersionTag = "v1";

        public Startup(IConfiguration configuration) => Configuration = configuration;

        private IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<KestrelServerOptions>(Configuration.GetSection("Kestrel"));

            services.AddScoped<IBootstrapCodeReview, BootstrapCodeReview>();
            services.AddScoped<IBootstrapAccessModifiers, BootstrapAccessModifiers>();
            services.AddScoped<IBootstrapArchitecturePattern, BootstrapArchitecturePattern>();
            services.AddScoped<IBootstrapDesignPattern, BootstrapDesignPattern>();
            services.AddScoped<IBootstrapSolidPrinciples, BootstrapSolidPrinciples>();
            services.AddScoped<IBootstrapOOP, BootstrapOOP>();
            services.AddScoped<IBootstrapApiWeb, BootstrapApiWeb>();

            services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
            services.AddSwaggerGen(SetSwaggerOption);

        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{TitleApi} {VersionTag}"); });
            app.UseRouting();
            app.UseCors();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
        
        private void SetSwaggerOption(SwaggerGenOptions swaggerOptions)
        {
            swaggerOptions.SwaggerDoc("v1", new OpenApiInfo { Title = TitleApi, Version = VersionTag });
            swaggerOptions.OrderActionsBy(api => api.HttpMethod);
        }

    }
}
