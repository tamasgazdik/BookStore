using Asp.Versioning;
using BookStore.Infrastructure;
using BookStore.Application.Commands;
using BookStore.Application.Validation;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using BookStore.Application.Repository;
using System.Text.Json.Serialization;
using FluentValidation;
using BookStore.Application.Commands.AddBookCommand;
using FluentValidation.Validators;
using BookStore.Application.Commands.ModifyBookCommand;

namespace BookStore.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ApiVersionReader = new UrlSegmentApiVersionReader();
            });

            builder.Services.AddControllers()
                            .AddJsonOptions(options =>
                            {
                                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                            });

            builder.Services.AddCustomCors(builder.Configuration);

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "BookStore API v1.0", Version = "v1.0" });
            });

            builder.Services.AddDbContext<BookStoreDbContext>(options =>
                options.UseNpgsql(
                    builder.Configuration.GetConnectionString("BookStoreConnectionString")
                ));

            builder.Services.AddCustomValidators();

            builder.Services.AddScoped<IBookStoreRepository, BookStoreRepository>();
            builder.Services.AddMediatR();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "BookStore API v1.0");
                });
            }

            app.UseHttpsRedirection();
            app.UseCustomCors();

            //app.UseAuthorization();

            app.MapControllers();
            
            app.Run();
        }
    }
}
