using ETicaretAPI.Application;
using ETicaretAPI.Application.Validators;
using ETicaretAPI.Infrastructure;
using ETicaretAPI.Persistence;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace ETicaretAPI.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddPersistenceServices(builder.Configuration);
            builder.Services.AddInfrastructureServices();
            builder.Services.AddAplicationServices();

            builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
            policy.WithOrigins("http://localhost:1425").AllowAnyHeader().AllowAnyMethod())); //Cors Politikasi
            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddFluentValidationClientsideAdapters();

            //Burada validator-larý assembly - d ? n qeydiyyatdan keçiririk
            builder.Services.AddValidatorsFromAssemblyContaining<CreateProductValidators>();

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

            app.UseStaticFiles(); //wwwroot qovluðundaký statik fayllara (.html, .css, .js, .png, .jpg v? s.) icaze verir

            app.UseCors();
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
