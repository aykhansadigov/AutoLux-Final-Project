
using AutoLux.Application.Abstractions;
using AutoLux.Persistence.Context;
using AutoLux.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace AutoLux.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

         
            builder.Services.AddDbContext<AutoLuxDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
           
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddAutoMapper(typeof(AutoLux.Application.Mappers.MappingProfile));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
