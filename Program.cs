using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using nft_project.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//People custom!
//Add seviceCors 
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

//Configurate data

builder.Services.AddDbContext<AuctionDBContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("SqlSever")));

builder.Services.AddDbContext<CampaignDBContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("SqlSever")));

builder.Services.AddDbContext<TransDBContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("SqlSever")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("corsapp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
