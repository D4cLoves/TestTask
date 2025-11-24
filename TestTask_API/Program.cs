using Microsoft.EntityFrameworkCore;
using TestTask_Application.Services;
using TestTask_Domain.Entites;
using TestTask_Domain.Interfaces;
using TestTask_Domain.ValueObject;
using TestTask_Infrastructure.Data;
using TestTask_Infrastructure.Repositories;

namespace TestTask_API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.AddServiceDefaults();

        builder.Services.AddAuthorization();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddControllers();
        
        //builder.Services.AddApplicationDbContext("Data Source=testtask.db");
        var connectionString = builder.Configuration.GetConnectionString("sqlitedb") 
                               ?? "Data Source=testtask.db";
        builder.Services.AddApplicationDbContext(connectionString);
        
        
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowVite", policy =>
            {
                policy.WithOrigins(
                        "http://localhost:5173"
                    )
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
        });

        builder.Services.AddScoped<IPatientRepository, PatientRepository>();
        builder.Services.AddScoped<PatientRepository>();
        builder.Services.AddScoped<IDieseasRepository, DiseaseRepository>();
        builder.Services.AddScoped<DiseaseRepository>();
        builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
        builder.Services.AddScoped<DoctorRepository>();
        
        builder.Services.AddScoped<PatientService>();
        builder.Services.AddScoped<DiseaseService>();
        builder.Services.AddScoped<DoctorService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseCors("AllowVite");
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        
        app.MapControllers();

        app.MapDefaultEndpoints();

        app.Run();
    }
}