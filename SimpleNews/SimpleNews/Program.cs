using SimpleNews.Application.Services;
using SimpleNews.Domain.Interfaces;
using SimpleNews.Domain.Models.Auth;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options => {
    options.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();

builder.Services.AddHttpClient<INewsService>("GNewsClient", client =>
{
    client.BaseAddress = new Uri(builder.Configuration.GetSection("GoogleNewsConnection:Url").Value);
});
builder.Services.AddSingleton(new ApiKey(builder.Configuration.GetSection("GoogleNewsConnection:ApiKey").Value));
builder.Services.AddTransient<INewsService, NewsService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
