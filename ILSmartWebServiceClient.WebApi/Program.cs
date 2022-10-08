using ILSmartServiceReference;
using ILSmartWebServiceClient.Data;
using ILSmartWebServiceClient.Data.Database;
using ILSmarWebServiceClient.LIbrary;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddEntityFrameworkNpgsql().AddDbContext<ILSmartWebServiceClientDbContext>(opt =>
        opt.UseNpgsql(builder.Configuration.GetConnectionString("ILSmartClientDataConnection")));

builder.Services.AddScoped<ILSmartWebServiceClientRepository, ILSmartWebServiceClientRepository>();
builder.Services.AddScoped<ISyncReply, SyncReplyClient>();
builder.Services.AddScoped<ILSmarWebServiceClientService, ILSmarWebServiceClientService>();

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

