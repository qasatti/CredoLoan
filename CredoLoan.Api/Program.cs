using CredoLoan.Api.Configurations;
using CredoLoan.Api.Validations;
using CredoLoan.Api.ViewModels;
using CredoLoan.Core.Models;
using CredoLoan.Core.Services;
using CredoLoan.Data;
using CredoLoan.Data.Entities;
using CredoLoan.Data.IRepositories;
using CredoLoan.Data.Repositories;
using CredoLoan.Infrastructure.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.

// For Entity Framework
if (!string.IsNullOrEmpty(configuration.GetConnectionString("dbConnection")))
    builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("dbConnection")));
else
    builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase(databaseName: "CredoLoanTest"));

// For Identity
builder.Services.AddIdentity<Client, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddTransient<ILoanApplicationRepository, LoanApplicationRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IAuthService, AuthService>();
builder.Services.AddTransient<ILoanApplicationService, LoanApplicationService>();
builder.Services.AddTransient<ICredoCssService, CredoCssService>();

builder.Services.AddTransient<IValidator<SignUpViewModel>, SignUpViewModelValidator>();
builder.Services.AddTransient<IValidator<SignInViewModel>, SignInViewModelValidator>();
builder.Services.AddTransient<IValidator<CreateLoanApplicationViewModel>, CreateLoanApplicationViewModelValidator>();
builder.Services.AddTransient<IValidator<EditLoanApplicationViewModel>, EditLoanApplicationViewModelValidator>();


builder.Services.Configure<CssApiOptions>(options => configuration.GetSection("CssApiOptions").Bind(options));
builder.Services.Configure<JwtOptions>(options => configuration.GetSection("JwtOptions").Bind(options));

#region JWT Configuration

var jwtOptions = configuration.GetSection(nameof(JwtOptions)).Get<JwtOptions>();

// Adding Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
// Adding Jwt Bearer
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = false,
        ValidAudience = jwtOptions.Audience,
        ValidIssuer = jwtOptions.Issuer,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.IssuerSigningKey))
    };
});
#endregion
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddControllers()
                .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true)
                .AddFluentValidation();

#region Swagger Configuration
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Credo Loan API", Version = "v1" });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid JWT token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });
});

#endregion

builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.All;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpLogging();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
