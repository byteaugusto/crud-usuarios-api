using FluentValidation;
using Microsoft.EntityFrameworkCore;
using MinhaPrimeiraApi.Data;
using MinhaPrimeiraApi.Interface;
using MinhaPrimeiraApi.Repositories;
using MinhaPrimeiraApi.Services;
using MinhaPrimeiraApi.Validators;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUsuarioRepositoryInterface, UsuarioRepository>();
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddValidatorsFromAssemblyContaining<UsuarioCreateValidator>();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

var app = builder.Build();

app.UseCors("AllowAll");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
public partial class Program { }