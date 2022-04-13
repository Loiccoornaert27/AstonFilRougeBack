using AstonFilRouge_API.Models;
using AstonFilRouge_API.Datas;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using AstonFilRouge_API.Controllers.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
    .LogTo(Console.WriteLine, LogLevel.Information));
builder.Services.AddScoped<IRepository<User>, UserListRepository>();
builder.Services.AddScoped<IRepository<Address>, AddressListRepository>();
builder.Services.AddScoped<IRepository<Club>, ClubListRepository>();
builder.Services.AddScoped<IRepository<Course>, CourseListRepository>();
builder.Services.AddScoped<IRepository<OpeningDay>, OpeningDayListRepository>();
builder.Services.AddScoped<IRepository<Reservation>, ReservationListRepository>();
builder.Services.AddScoped<IRepository<Subscription>, SubscriptionListRepository>();
builder.Services.AddScoped<ReportingService>();

builder.Services.AddCors(options => {
    options.AddPolicy("allConnections", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["JWT:SecretKey"])),
        ValidateLifetime = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:ValidAudience"],
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        ClockSkew = TimeSpan.Zero

    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("allConnections");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
