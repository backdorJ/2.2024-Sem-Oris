using System.Text;
using Asp.GoodWeb.Data;
using Asp.GoodWeb.JwtService;
using Asp.GoodWeb.Options;
using Good.API.Services.Hasher;
using Good.API.Services.UserContext;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc(options =>
{
    options.Filters.Add(new IgnoreAntiforgeryTokenAttribute());
});
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<IDbContext, EfContext>(options =>
{
    options.UseNpgsql(builder.Configuration["ConnectionString"]);
});
builder.Services.Configure<JWTOptions>(builder.Configuration.GetSection(key: nameof(JWTOptions)));
builder.Services.AddHttpContextAccessor();
builder.Services.AddMediatR(conf => conf.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWTOptions:Key"]!))
        };
        
        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = (context) =>
            {
                context.Token = context.Request.Cookies["some-data"];
                return Task.CompletedTask;
            }
        };
    });
builder.Services.AddScoped<IHasherPassword, HasherPassword>();
builder.Services.AddScoped<IUserContext, UserContext>();
builder.Services.AddScoped<IJwtGenerator, JwtGenerator>();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(opt =>
    {
        opt.AllowAnyHeader();
        opt.AllowAnyMethod();
        opt.AllowAnyOrigin();
        opt.WithOrigins("http://localhost:21963/", "https://localhost:44384/");
    });
});
builder.Services.ConfigureApplicationCookie(opt =>
{
    opt.LoginPath = "/Auth/Login";
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();