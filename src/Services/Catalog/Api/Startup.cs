
using FluentValidation;
using JdMarketplace.App.Commands.Catalogo.CriarProduto;
using JdMarketplace.App.Commands.Catalogo.EditarProduto;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using ProAgil.Repository;
using System.IO;
using JdStore.Api.Configuration;
using JdStore.Api.Configurations;

namespace JdStore.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IHostEnvironment hostEnvironment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(hostEnvironment.ContentRootPath)
                //.AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{hostEnvironment.EnvironmentName}.json", true, true)
                .AddEnvironmentVariables();

            if (hostEnvironment.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CatalogoContext>(
                options => options.UseMongoDB(Configuration.GetConnectionString("MongoDbConection"), "JdStore-Catalog")
            );

            //services.AddMediatR(typeof(CriarProdutoHandler).Assembly);
            //services.AddMediatR(typeof(EditarProdutoHandler).Assembly);

            services.AddMediatR(typeof(CriarProdutoHandler).Assembly);

            services.AddTransient<IValidator<CriarProdutoRequest>, CriarProdutoValidator>();
            services.AddTransient<IValidator<EditarProdutoRequest>, EditarProdutoValidator>();

            services.AddValidatorsFromAssemblyContaining<CriarProdutoValidator>();

            services.AddApiConfiguration();

            services.AddSwaggerConfiguration();

            services.AddDependencyInjectionConfiguration();
            services.AddCors();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwaggerConfiguration();

            app.UseApiConfiguration(env);

            app.UseCors(x => x.AllowAnyHeader()
                             .AllowAnyMethod()
                             .AllowAnyOrigin());

            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Resources")),
                RequestPath = new PathString("/Resources")
            });

        }
    }
}
