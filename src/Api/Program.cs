using Application.Services;
using Domain.Interfaces;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BankDbContext>(options => options.UseInMemoryDatabase(databaseName: "BankDB"));
builder.Services.AddScoped<IBankAccountService, BankAccountService>();

var app = builder.Build();

// Seed the database with initial data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<BankDbContext>();
    SeedData.Seed(context);

    var checkingAccount = context.BankAccount.FirstOrDefault(a => a.AccountHolder == "Steve");
    if (checkingAccount == null)
    {
        throw new Exception("OH NO!");
    } 
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
