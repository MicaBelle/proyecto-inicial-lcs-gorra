using Gorra.apiminimal.Application;
using Gorra.apiminimal.Application.Data;
using Gorra.apiminimal.Infrestructure;
using Gorra.apiminimal.Routes.EndPoints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfraestructure(builder.Configuration);
builder.Services.AddApplication();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CustomCorsPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:3000", "https://gorra-seven.vercel.app")
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

//creacion de app
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

}

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("CustomCorsPolicy");

app.UseHttpsRedirection();
app.UseCertificateForwarding();


app.MapCitizen();
app.MapDenuncia();

app.Run();