using Domain.Interfaces.Generics;
using Domain.Interfaces.ICategory;
using Domain.Interfaces.IExpense;
using Domain.Interfaces.IFinancialSystem;
using Domain.Interfaces.IFinancialSystemUser;
using Entities.Entities;
using Infra.Configuracao;
using Infra.Repository;
using Infra.Repository.Generics;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ContextBase>(options =>
               options.UseSqlServer(
                   builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ContextBase>();



// INTERFACE AND REPOSITORY

builder.Services.AddSingleton(typeof(InterfaceGeneric<>), typeof(RepositoryGenerics<>));
builder.Services.AddSingleton<IFinancialSystem, FinancialSystemRepository>();
builder.Services.AddSingleton<IExpense, ExpenseRepository>();
builder.Services.AddSingleton<ICategory, CategoryRepository>();
builder.Services.AddSingleton<IFinancialSystemUser, FinancialSystemUserRepository>();


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
