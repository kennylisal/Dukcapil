using Backend;
using Backend.Data;
using Backend.Interfaces;
using Backend.Repository;
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

//Urusan controller
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IOrangRepos, OrangRepos>();
builder.Services.AddScoped<IAktaKelahiranRepos, AktaKelahiranRepos>();
builder.Services.AddScoped<IKtpRepos, KtpRepos>();
builder.Services.AddScoped<IAktaPernikahanRepos, AktaPernikahanRepos>();
builder.Services.AddScoped<IKartuKeluargaRepos, KartuKeluargaRepos>();
builder.Services.AddScoped<DataSeeder>();

// Check for --seed argument
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

    app.UseHttpsRedirection();

    app.MapControllers();

    app.Run();
}

// Configure the HTTP request pipeline.

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
