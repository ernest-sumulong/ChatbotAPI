using ChatbotAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<ChatbotAPIContext>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("ChatbotAPIDB"),
    Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.23-mysql"));
});

var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetService<IConfiguration>();

builder.Services.AddCors(Options =>
{
    var frontendURL = configuration.GetValue<string>("frontend_url");
});


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
