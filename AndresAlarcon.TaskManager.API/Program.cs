using AndresAlarcon.TaskManager.Application.Security;
using AndresAlarcon.TaskManager.Infrastructure.Data;
using AndresAlarcon.TaskManager.Infrastructure.Repositories.Contracts;
using AndresAlarcon.TaskManager.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using AndresAlarcon.TaskManager.Application.Repositories;
using AndresAlarcon.TaskManager.Application.Services;
using AndresAlarcon.TaskManager.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using System.Reflection;
using AndresAlarcon.TaskManager.API.Helpers;

var builder = WebApplication.CreateBuilder(args);

var jwtSecuritySettingsSection = builder.Configuration.GetSection(nameof(JwtSecuritySettings));

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("LocalDB")));

builder.Services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITaskBoardService, TaskBoardService>();

builder.Services.Configure<JwtSecuritySettings>(jwtSecuritySettingsSection);
builder.Services.AddIdentityJwt(builder.Configuration);
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "TaskManager API",
        Version = "v1",
        Description = "API para la gestion de tareas, proyecto realizado por ANDRÉS ALARCÓN para Amadeus como prueba técnica.",
        Contact = new OpenApiContact
        {
            Name = "Andrés Camilo Alarcón Rátiva",
            Email = "acalarcon7@gmail.com",
        },
    });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";


    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = "Jwt Authorization. **Token only**",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    options.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
    options.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            securityScheme,
            new List<string>()
        }
    });
});
builder.Services.AddControllers();

builder.Services.AddCors(cors =>
{
    cors.AddPolicy("AllowAnyOrigin", builder =>
    {
        builder.AllowAnyOrigin().
        AllowAnyHeader().
        AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAnyOrigin");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
