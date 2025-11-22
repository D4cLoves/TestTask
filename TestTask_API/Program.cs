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

        //builder.Services.AddScoped<PatientService>();
        builder.Services.AddScoped<IPatientRepository, PatientRepository>();

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

        using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    
    // Убедись что база создана
    context.Database.EnsureCreated();
    
    // Проверяем есть ли данные
    if (!context.Patients.Any())
    {
        Console.WriteLine("Добавляем тестовые данные...");
        
        // Создаем докторов
        var doctor1 = new Doctor(
            new FullName("Иван Сергеевич"), 
            "Терапевт", 
            new DateTime(1975, 3, 15)
        );
        
        var doctor2 = new Doctor(
            new FullName("Мария Петрова"), 
            "Хирург", 
            new DateTime(1980, 7, 22)
        );

        context.Doctors.AddRange(doctor1, doctor2);
        context.SaveChangesAsync();

        // Создаем пациентов
        var patient1 = new Patient(
            new FullName("Алексей Иванов"),
            new DateTime(1990, 1, 1),
            doctor1.Id
        );
        
        var patient2 = new Patient(
            new FullName("Ольга Сидорова"), 
            new DateTime(1985, 5, 15),
            doctor2.Id
        );

        context.Patients.AddRange(patient1, patient2);
         context.SaveChangesAsync();

        // Создаем болезни
        var disease1 = new Disease("Грипп", "Острое респираторное заболевание");
        var disease2 = new Disease("Гастрит", "Воспаление слизистой желудка");
        var disease3 = new Disease("Мигрень", "Сильная головная боль");

        context.Diseases.AddRange(disease1, disease2, disease3);
         context.SaveChangesAsync();

        // Добавляем связи многие-ко-многим
        // Для этого нужен доступ к промежуточной таблице
         context.Database.ExecuteSqlRawAsync(@"
            INSERT INTO PatientDisease (PatientId, DiseaseId) VALUES
            ({0}, {1}),
            ({0}, {2}),
            ({3}, {1}),
            ({3}, {4})
        ", patient1.Id, disease1.Id, disease2.Id, patient2.Id, disease3.Id);

        Console.WriteLine("Тестовые данные добавлены!");
    }
}

        app.Run();
    }
}