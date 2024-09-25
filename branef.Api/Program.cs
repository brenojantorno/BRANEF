using branef.CrossCutting.IoC;
using Microsoft.OpenApi.Models;
var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "BRANEF API",
        Description = "BRANEF API",
        Contact = new OpenApiContact()
        {
            Name = "Breno Jantorno Ferreira",
            Email = "brenojantorno1@gmail.com",
            Url = new Uri("https://www.linkedin.com/in/breno-jantorno-ferreira-185093195/"),

        },
    });
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(op =>
    {
        op.AllowAnyOrigin();
        op.AllowAnyHeader();
        op.AllowAnyMethod();
    });

});


builder.Services.AddInfraServices(builder.Configuration);

var app = builder.Build();

await app.ApplyMigrations();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapControllers();
app.UseHttpsRedirection();
app.UseCors();


await app.RunAsync();
