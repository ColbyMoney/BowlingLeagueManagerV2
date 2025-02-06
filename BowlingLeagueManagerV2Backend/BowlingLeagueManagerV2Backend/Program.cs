using BowlingLeagueManagerV2Backend.Services;
using BowlingLeagueManagerV2Backend.Repositories;
using BowlingLeagueManagerV2Backend.Data;
using Microsoft.EntityFrameworkCore;
using BowlingLeagueManagerV2Backend.DTOs;

var builder = WebApplication.CreateBuilder(args);

// Add CORS policy to allow requests from Angular
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        builder => builder
            .WithOrigins("http://localhost:4200") // Replace with the actual URL of your Angular app
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()); // Use if you need cookies or auth headers
});

// Add services to the container.
builder.Services.AddControllers();

// Register your services
builder.Services.AddScoped<IBowlerService, BowlerService>();
builder.Services.AddScoped<IBowlerRepository, BowlerRepository>();
builder.Services.AddScoped<ISeriesService, SeriesService>();
builder.Services.AddScoped<ISeriesRepository, SeriesRepository>();
builder.Services.AddScoped<IBowlerLeagueComboService, BowlerLeagueComboService>();
builder.Services.AddScoped<IBowlerLeagueComboRepository, BowlerLeagueComboRepository>();
builder.Services.AddScoped<ILeagueService, LeagueService>();
builder.Services.AddScoped<ILeagueRepository, LeagueRepository>();
builder.Services.AddScoped<ITeamService, TeamService>();
builder.Services.AddScoped<ITeamRepository, TeamRepository>();
builder.Services.AddScoped<DtoService>();
builder.Services.AddScoped<DtoRepository>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();

// Register your DbContext with the SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add Swagger for API documentation (optional)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Use the CORS policy
app.UseCors("AllowAngularApp");

app.UseAuthorization();

app.MapControllers();

app.Run();
