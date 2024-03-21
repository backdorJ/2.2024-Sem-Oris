using System.Reflection;
using Microsoft.EntityFrameworkCore;
using PokemonAPI.Core;
using PokemonAPI.Core.Abstractions;
using PokemonAPI.DAL.PostgreSQL;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddDbContext<EfContext>(opt => opt.UseNpgsql(builder.Configuration["ConnectionString:DefaultConnection"]));
builder.Services.AddPostgreSQLCore();
builder.Services.AddHttpClient();
builder.Services.AddCore();
builder.Services.AddCors(options =>
{
    options
        .AddPolicy(
            "AllowAnyOrigin",
            opt => opt.AllowAnyOrigin());
});
builder.Services.AddLogging();

var app = builder.Build();

using var scope = app.Services.CreateScope();
var dbSeeder = scope.ServiceProvider.GetRequiredService<IDbSeeder>();
await dbSeeder.SeedAsync(new CancellationToken());

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("AllowAnyOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();