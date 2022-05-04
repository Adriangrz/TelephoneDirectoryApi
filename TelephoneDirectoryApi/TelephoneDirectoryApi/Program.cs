using Microsoft.EntityFrameworkCore;
using TelephoneDirectoryApi.Database;
using TelephoneDirectoryApi.Database.Repository;
using TelephoneDirectoryApi.Database.Repository.Interfaces;
using TelephoneDirectoryApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseInMemoryDatabase(databaseName: "TelephoneDirectoryApiDatabase");
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IGenericRepositoryy<EntryInTelephoneDirectory>, GenericRepository<EntryInTelephoneDirectory>>();

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
