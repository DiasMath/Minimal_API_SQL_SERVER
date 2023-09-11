using Microsoft.EntityFrameworkCore;
using Minimal_API_SQL_SERVER.Data;
using Minimal_API_SQL_SERVER.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

async Task<List<Livros>> GetLivros(DataContext context) => await context.Livros.ToListAsync();

// Create
app.MapPost("Add/Livros", async (DataContext context, Livros item) =>
{
    context.Livros.Add(item);
    await context.SaveChangesAsync();
    return Results.Ok(await GetLivros(context));
});

// Read
app.MapGet("/Livros", async (DataContext context) => await context.Livros.ToListAsync());

app.MapGet("/Livros/{id}", async (DataContext context, int id) =>
    await context.Livros.FindAsync(id) is Livros item ? 
    Results.Ok(item) : Results.NotFound("Livro não encontrado"));


// Upodate
app.MapPost("/Livros/{id}", async (DataContext context, Livros item, int id) =>
{
    var livroItem = await context.Livros.FindAsync(id);
    if (livroItem == null) return Results.NotFound("Livro não encontrado");

    livroItem.Nome = item.Nome;
    livroItem.Editora = item.Editora;
    livroItem.Genero = item.Genero;
    livroItem.Preco = item.Preco;

    context.Livros.Update(livroItem);
    await context.SaveChangesAsync();
    return Results.Ok(await GetLivros(context));
});

// Delete
app.MapPost("/Livros/{id}", async (DataContext context, int id) =>
{
    var livroItem = await context.Livros.FindAsync(id);
    if (livroItem == null) return Results.NotFound("Livro não encontrado");

    context.Livros.Remove(livroItem);
    await context.SaveChangesAsync();
    return Results.Ok(await GetLivros(context));
});


app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
