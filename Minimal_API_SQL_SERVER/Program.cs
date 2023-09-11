using Microsoft.EntityFrameworkCore;
using Minimal_API_SQL_SERVER.Data;
using Minimal_API_SQL_SERVER.Models;

var builder = WebApplication.CreateBuilder(args);

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


async Task<List<Livro>> GetLivros(DataContext context) => await context.Livros.ToListAsync();


// Create
app.MapPost("Add/Livro", async (DataContext context, Livro item) =>
{
    context.Livros.Add(item);
    await context.SaveChangesAsync();
    return Results.Ok(await GetLivros(context));
})
.WithName("AddLivro")
.WithOpenApi();


// Read
app.MapGet("/Livro", async (DataContext context) =>
await context.Livros.ToListAsync())
.WithName("GetLivro")
.WithOpenApi(); ;


// Read By Id
app.MapGet("/Livro/{id}", async (DataContext context, int id) =>
    await context.Livros.FindAsync(id) is Livro item? 
    Results.Ok(item) : Results.NotFound("Livro não encontrado"))
    .WithName("GetLivroById")
    .WithOpenApi();


// Upodate
app.MapPut("/Livro/{id}", async (DataContext context, Livro item, int id) =>
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
})
.WithName("UpdateLivroById")
.WithOpenApi();


// Delete
app.MapDelete("/Livro/{id}", async (DataContext context, int id) =>
{
    var livroItem = await context.Livros.FindAsync(id);
    if (livroItem == null) return Results.NotFound("Livro não encontrado");

    context.Remove(livroItem);
    await context.SaveChangesAsync();
    return Results.Ok(await GetLivros(context));
})
.WithName("DeleteLivroById")
.WithOpenApi();


app.Run();