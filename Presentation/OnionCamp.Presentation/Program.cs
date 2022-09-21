using FluentValidation.AspNetCore;
using OninoCamp.Infrastructure.Filters;
using OnionCamp.Application.Validation.Products;
using OnionCamp.Persistance;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistanceServices();

//builder.Services.AddCors(options => options.AddDefaultPolicy(
//policy => policy.WithOrigins("http://localhost:4200/", "https://localhost:4200/").AllowAnyHeader().AllowAnyMethod()));

builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
    policy.WithOrigins("http://localhost:4200", "https://localhost:4200").AllowAnyHeader().AllowAnyMethod().AllowCredentials()
));

builder.Services.AddControllers(options => options.Filters.Add<ValidationFilter>())
    .AddFluentValidation(configuration => configuration
    .RegisterValidatorsFromAssemblyContaining<CreateProductValidator>())
    .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter=true);

builder.Services.AddEndpointsApiExplorer();   
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

//app.UseCors(builder => builder.WithOrigins("http://localhost:4200").AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
