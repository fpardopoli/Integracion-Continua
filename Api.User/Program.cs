using Api.User.Core.ContextSqlServerDB;
using Api.User.Core.DatabaseManagementService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<ContextSqlServerDB>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexionDB"));
});

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsRule", rule =>
    {
        rule.AllowAnyHeader().AllowAnyMethod().WithOrigins("*");
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

DatabaseManagementService.MigrationInitialisation(app);

app.UseCors("CorsRule");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
