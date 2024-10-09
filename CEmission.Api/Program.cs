using CEmission.Api;
using CEmission.Companies;
using CEmission.DbMigrator;
using CEmission.Emissions;
using CEmission.EntityFramework;
using CEmission.IdentityUsers;
using CEmission.Localization;
using CEmission.LoginAppServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Events;
using System.Globalization;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApiDbContext>(options => options.UseMySQL(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => {
    options.TokenValidationParameters = new TokenValidationParameters {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };

});

builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CEmissions", Version = "V1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme {
        Description = "Jwt Authorization",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

#region Dependency Injection

builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<ICompanyAppServices, CompanyAppServices>();
builder.Services.AddScoped<IEmissionAppServices, EmissionAppServices>();
builder.Services.AddScoped<IEmissionRepository, EmissionRepository>();
builder.Services.AddScoped<IIdentityUserRepository, IdentityUserRepository>();
builder.Services.AddScoped<IIdentityUserAppServices, IdentityUserAppServices>();
builder.Services.AddScoped<ILoginAppServices, LoginAppServices>();

#endregion

#region Logger Config
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
#if DEBUG
    .MinimumLevel.Information()
#endif
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
    .Enrich.FromLogContext()
#if DEBUG
    .WriteTo.Async(c => c.File("Logs/logsInfo.txt", restrictedToMinimumLevel: LogEventLevel.Debug, rollingInterval: RollingInterval.Day))
#endif
    .WriteTo.Async(c => c.File("Logs/logsWarn.txt", restrictedToMinimumLevel: LogEventLevel.Warning, rollingInterval: RollingInterval.Day))

    .CreateLogger();
#endregion

#region GlobalExceptionHandler

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

#endregion

#region Cors Config

if (builder.Configuration.GetValue<bool>("App:EnableCors")) {
    builder.Services.AddCors(options =>
    options.AddDefaultPolicy(policy =>
        policy.WithOrigins(
            builder.Configuration["App:CorsOrigins"]?
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .Select(o => o.Trim())
                .ToArray() ?? Array.Empty<string>()
            )
        .SetIsOriginAllowedToAllowWildcardSubdomains()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials()
    ));
}
#endregion

builder.Services.AddLocalization();
builder.Services.AddSingleton<LocalizerMiddleware>();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSingleton<IStringLocalizerFactory, JsonStringLocalizerFactory>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

var options = new RequestLocalizationOptions {
    DefaultRequestCulture = new RequestCulture(new CultureInfo("es-ES"))
};

app.UseRequestLocalization(options);

app.UseExceptionHandler();

if (builder.Configuration.GetValue<bool>("App:EnableCors")) {
    app.UseCors();
}
app.MapControllers();

if (builder.Configuration.GetValue<bool>("App:ExecuteMigrations")) {
    app.MigrateDatabase();
}

app.Run();


public partial class Program { }