using TestTask_Infrastructure.Data;
namespace TestTask_API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddAuthorization();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddControllers();
        
        builder.Services.AddApplicationDbContext("Data Source=testtask.db");
        
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

        app.Run();
    }
}