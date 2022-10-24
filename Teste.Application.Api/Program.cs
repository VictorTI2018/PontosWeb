using Microsoft.EntityFrameworkCore;
using Serilog.Sinks.MSSqlServer.Sinks.MSSqlServer.Options;
using Serilog.Sinks.MSSqlServer;
using Serilog;
using System.Configuration;
using Teste.Infra.CrossCutting.IOC;
using Teste.Infra.Data.Context;
using Microsoft.OpenApi.Models;
using AutoMapper;
using Teste.Infra.Shared.MapperDto;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

#region Mapper
var config = new MapperConfiguration(conf =>
{
    conf.AddProfile<MapperDtoProfile>();
});

IMapper mapper = config.CreateMapper();

builder.Services.AddSingleton(mapper);

#endregion Mapper

#region swagger doc
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Teste API",
        Description = "Api criada para teste",
    });
});
#endregion swagger doc

#region Conexão com o banco de dados
var connection = builder.Configuration.GetConnectionString("SqlConnectionString");
builder.Services.AddDbContext<SqlContext>(options =>
{
    options.UseSqlServer(connection);
});
#endregion Conexão com o banco de dados

builder.Services.AddRepositoryDependency();
builder.Services.AddServicesDependency();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    });
}

app.UseAuthorization();

app.MapControllers();

app.Run();
