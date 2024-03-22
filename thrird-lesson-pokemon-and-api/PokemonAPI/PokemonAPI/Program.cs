using System.Reflection;
using PokemonAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});
//builder.Services.AddCore();
//builder.Services.AddDbContext<EfContext>(opt => opt.UseNpgsql(builder.Configuration["ConnectionStrings:DefaultConnection"]));
builder.Services.AddHttpClient();
builder.Services.AddCors(options =>
{
    options
        .AddPolicy(
            "AllowAnyOrigin",
            opt => opt.AllowAnyOrigin());
});
// Add Redis
builder.Services.AddStackExchangeRedisCache((opt) =>
{
    var configuration = builder.Configuration;
    opt.Configuration = configuration.GetValue<string>("CacheSettings:RedisConnection");
});
builder.Services.AddScoped<IPokeApiService, PokeApiService>();
builder.Services.AddLogging();

var app = builder.Build();

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