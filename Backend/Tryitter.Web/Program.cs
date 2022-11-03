using tryitter.Context;
using Microsoft.EntityFrameworkCore;
using tryitter.UserRepository;
using tryitter.PostRepository;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<TryitterContext>(options =>
{
    string connectionString = @"Server=localhost; Database=tryitter_db; Uid=root; Pwd=123456;";
    options.UseMySql(connectionString,
        ServerVersion.AutoDetect(connectionString),
        mySqlOptions =>
            mySqlOptions.EnableRetryOnFailure(
                maxRetryCount: 10,
                maxRetryDelay: TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null)
        );
});
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<PostRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => 
{
    string file = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    string path = Path.Combine(AppContext.BaseDirectory, file);
    options.IncludeXmlComments(path);
    options.SwaggerDoc(
        "v1", 
        new OpenApiInfo { 
            Title = "Blogs API Tryitter", 
            Description = "Uma API de blogs ao estilo do Twitter!",
            Version = "v1"
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using(var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<TryitterContext>();
    context.Database.EnsureDeleted();
    context.Database.EnsureCreated();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
