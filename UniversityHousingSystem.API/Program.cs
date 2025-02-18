using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using UniversityHousingSystem.Core;
using UniversityHousingSystem.Core.Middleware;
using UniversityHousingSystem.Infrastructure;
using UniversityHousingSystem.Infrastructure.Context;
using UniversityHousingSystem.Service;

namespace UniversityHousingSystem.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            #region Swagger
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            //Swagger Gn
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "University Housing System",
                    Version = "V1",
                    Description = "An API for University Housing System, providing endpoints for users to:<br>" +
                                  "- bla bla bla bla<br>" +
                                  "- bla bla bla bla<br>" +
                                  "- bla bla bla bla<br><br>" +
                                  "Designed for efficient and user-friendly integration with web and mobile applications.",
                    Contact = new OpenApiContact()
                    {
                        Name = "Mohamed Amer & Kero Morcos",
                        Email = "mohamedamer8921@gmail.com",
                        Url = new Uri("https://www.linkedin.com/in/mohamed-m-aamer/")
                    }
                });
                c.EnableAnnotations();
            });
            #endregion

            #region DbContext
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            #endregion

            #region Modules Interfaces
            builder.Services.AddModuleInfrastructureDependencies();
            builder.Services.AddModuleServicesDependencies();
            builder.Services.AddModuleCoreDependencies();
            #endregion

            #region CORS
            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                                      policy =>
                                      {
                                          policy.AllowAnyOrigin()
                                                .AllowAnyHeader()
                                                .AllowAnyMethod();
                                      });
            });
            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseMiddleware<ErrorHandlerMiddleware>();
            app.UseHttpsRedirection();

            app.UseCors(MyAllowSpecificOrigins);
            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
