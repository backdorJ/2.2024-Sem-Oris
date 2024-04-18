using System.Net;
using LiveStreamingServerNet;
using LiveStreamingServerNet.Flv.Installer;
using LiveStreamingServerNet.Networking.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TeamHost.Application;
using TeamHost.Application.Interfaces;
using TeamHost.Cors;
using TeamHost.Domain.Entities;
using TeamHost.Hub;
using TeamHost.Infrastructure;
using TeamHost.Infrastructure.Services;
using TeamHost.Persistence;
using TeamHost.Persistence.Context;
using TeamHost.Persistence.Extensions;

await using var liveStreamingServer = LiveStreamingServerBuilder.Create()
    .ConfigureRtmpServer(options => options.AddFlv())
    .ConfigureLogging(options => options.AddConsole())
    .Build();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<EfContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")))
    .Configure<IdentityOptions>(opt =>
    {
        opt.Password.RequireDigit = false;
        opt.Password.RequiredLength = 5;
        opt.Password.RequireUppercase = false;
        opt.Password.RequireNonAlphanumeric = false;
    })
    .AddIdentity<User, IdentityRole<Guid>>()
    .AddDefaultTokenProviders()
    .AddEntityFrameworkStores<EfContext>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Profile/Login";
});
builder.Services.AddInfrastructure();
builder.Services.AddPersistenceLayer();
builder.Services.AddApplicationLayer();
builder.Services.AddBackgroundServer(liveStreamingServer, new IPEndPoint(IPAddress.Any, 1935));
builder.Services.AddCors(x =>
{
    x.AddPolicy("AllowAll", opt =>  
    {
        opt.AllowAnyOrigin();
        opt.AllowAnyHeader();
    });
});
builder.Services.AddSignalR()
    .Services.AddSingleton<IHubService, HubService>();
builder.Services.AddSwaggerGen();


var app = builder.Build();

using var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<IDbSeeder>();
var migrator = scope.ServiceProvider.GetRequiredService<Migrator>();
await seeder.SeedAsync(new CancellationToken());
await migrator.MigrateAsync();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
});

app.UseWebSockets();
app.UseWebSocketFlv(liveStreamingServer);

app.UseHttpFlv(liveStreamingServer);

app.UseCors(CorsPolicy.AllowAll);
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapHub<ChatHub>("ws/chat");
app.MapControllerRoute(
    name: "MyArea",
    pattern: "{area=Home}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "GetChatDetail",
    pattern: "{area=Account}/{controller=Chat}/{action=GetChatDetail}/{id?}"
);

app.Run();