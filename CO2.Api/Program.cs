using CO2.Api;
using CO2.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApiDbContext>(options => options.UseMySQL(builder.Configuration.GetConnectionString("Default")));

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

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseExceptionHandler();
if (builder.Configuration.GetValue<bool>("App:EnableCors")) {
    app.UseCors();
}
app.MapControllers();

app.Run();
