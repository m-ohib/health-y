using HealthY.Api.Extensions;
using HealthY.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using System.Text.Json.Serialization;

const string FrontendCorsPolicy = "Frontend";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(o => o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
builder.Services.AddOpenApi();
builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<ValidationExceptionHandler>();

// Alle afhængigheder registreres her: Core-services og Infrastructure (database, Identity, repositories).
builder.Services.AddCore();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        // TODO: Sæt options.TokenValidationParameters = new TokenValidationParameters { ... } med
        //       ValidateIssuer, ValidateAudience, ValidateLifetime og ValidateIssuerSigningKey = true,
        //       ValidIssuer/ValidAudience fra "Jwt"-sektionen, IssuerSigningKey fra Jwt:Key,
        //       og ClockSkew = TimeSpan.FromMinutes(1).
        // TIP: Læs værdierne med builder.Configuration.GetSection(JwtOptions.SectionName).Get<JwtOptions>().
    });

// Alt kræver login, medmindre det er markeret [AllowAnonymous]. Så åbner et glemt [Authorize] ikke et endpoint.
builder.Services.AddAuthorizationBuilder()
    .SetFallbackPolicy(new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build());

// Frontend og API kører på hver sit domæne, så kun de origins, der står i konfigurationen, må kalde API'et.
var allowedOrigins = builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>() ?? [];
builder.Services.AddCors(options =>
{
    options.AddPolicy(FrontendCorsPolicy, policy => policy
        .WithOrigins(allowedOrigins)
        .AllowAnyHeader()
        .AllowAnyMethod());
});

var app = builder.Build();

app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi().AllowAnonymous();
}
else
{
    app.UseHsts();
}

app.UseStatusCodePages();
app.UseHttpsRedirection();
app.UseCors(FrontendCorsPolicy);
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
