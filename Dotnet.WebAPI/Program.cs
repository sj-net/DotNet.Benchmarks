using Dotnet.WebAPI.Controllers;
using Dotnet.WebAPI.Formatters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.DependencyInjection;

var d = new SerialzationController();
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddControllers(options =>
{
    // using Microsoft.AspNetCore.Mvc.Formatters;
    options.OutputFormatters.Insert(0, new MessagePackOutputFormatter());
});

builder.Services.AddResponseCompression(options =>
{
    options.Providers.Add<BrotliCompressionProvider>();
    options.Providers.Add<GzipCompressionProvider>();
});


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseResponseCompression();
app.UseAuthorization();
app.MapControllers();

app.Run();
