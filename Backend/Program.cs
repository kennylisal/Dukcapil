using System.Text.Json;
using System.Text.Json.Serialization;
using Backend;
using Backend.Controllers.Config;
using Backend.Data;
using Backend.Domain.Repositories;
using Backend.Domain.Services;
using Backend.Helper;
using Backend.Interfaces;
using Backend.Middlewares;
using Backend.Persistence.Repositories;
using Backend.Repository;
using Backend.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

//urusan DB
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder
    .Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.InvalidModelStateResponseFactory =
            InvalidModelStateResponseFactory.ProduceErrorResponse;
    });
builder
    .Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new KewarganegaraanConverter());
    });

//Urusan controller
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//repos
builder.Services.AddScoped<IOrangRepos, OrangRepos>();
builder.Services.AddScoped<IAktaKelahiranRepos, AktaKelahiranRepos>();
builder.Services.AddScoped<IKtpRepos, KtpRepos>();
builder.Services.AddScoped<IAktaPernikahanRepos, AktaPernikahanRepos>();
builder.Services.AddScoped<IKartuKeluargaRepos, KartuKeluargaRepos>();
builder.Services.AddScoped<IAnggotaKKRepos, AnggotaKKrepos>();
builder.Services.AddScoped<IUnitOfWorks, UnitOfWorks>();

//services
builder.Services.AddScoped<IOrangServices, OrangService>();
builder.Services.AddScoped<IAktaKelahiranServices, AktaKelahiranService>();
builder.Services.AddScoped<IKtpServices, KtpService>();
builder.Services.AddScoped<IAktaPernikahanServices, AktaPernikahanServices>();
builder.Services.AddScoped<IKartuKeluargaService, KartuKeluargaService>();
builder.Services.AddScoped<IAnggotaKKServices, AnggotaKKService>();

builder.Services.AddScoped<DataSeeder>();

// untuk seeding
if (args.Contains("--seed"))
{
    await SeederProgram.Main(args);
}
else
{
    // Normal Web API startup
    var app = builder.Build();
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseMiddleware<ExceptionMiddleware>();

    app.UseHttpsRedirection();

    app.MapControllers();

    app.Run();
}


// app.MapGet(
//     "/test-db",
//     async (DataContext context) =>
//     {
//         try
//         {
//             // Attempt to connect to the database
//             await context.Database.OpenConnectionAsync();
//             Console.WriteLine("Halo");
//             await context.Database.CloseConnectionAsync();
//             return Results.Ok("Database connection successful!");
//         }
//         catch (Exception ex)
//         {
//             return Results.Problem($"Database connection failed: {ex.Message}");
//         }
//     }
// );
