using ApiCalc.Facades;
using ApiCalc.Facades.Interfaces;
using ApiCalc.Service;
using ApiCalc.Service.Interfaces;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("pt-BR");
CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("pt-BR");

builder.Services.AddScoped<ICalculoService, CalculoService>();
builder.Services.AddHttpClient<ITaxFacade, TaxFacade>(cfg =>
{
    cfg.BaseAddress = new Uri(builder.Configuration.GetSection("BaseTaxApi").Value!);
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
