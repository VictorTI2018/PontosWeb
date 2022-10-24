using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Teste.WebMvc.Services;
using Teste.WebMvc.Services.Interfaces;
using Teste.WebMvc.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IServiceCategoriaMVC, ServiceCategoriaMVC>();
builder.Services.AddScoped<IServiceProdutosMVC, ServiceProdutosMVC>();

builder.Services.AddHttpClient("namedType", c =>
{
    var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
    c.BaseAddress = new Uri(configuration.GetSection("ApiUrl:TesteApi").Value);
});


var configuration = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new MapperDtoProfile());
});

IMapper mapper = configuration.CreateMapper();
builder.Services.AddSingleton(mapper);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
