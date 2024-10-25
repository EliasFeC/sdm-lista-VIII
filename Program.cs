using Microsoft.EntityFrameworkCore;
using BibliotecaApi.Data;
using BibliotecaApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString= builder.Configuration.GetConnectionString("Biblioteca") ?? "Data Source=BibliotecaDataBase.db";
builder.Services.AddSqlite<AppDbContext>(connectionString);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.MapGet("/biblioteca", async(AppDbContext db) => await db.Biblioteca.ToListAsync());

app.MapPost("/biblioteca", async (AppDbContext db, Biblioteca biblioteca) =>
{
  await db.Biblioteca.AddAsync(biblioteca);
  await db.SaveChangesAsync();
  return Results.Created($"/biblioteca/{biblioteca.Id}", biblioteca);
});
app.MapDelete("/biblioteca/{id:int}", async (int id, AppDbContext db) =>
{
  var biblioteca = await db.Biblioteca.FindAsync(id);
  if (biblioteca == null) {
    return Results.NotFound();
  }
  db.Biblioteca.Remove(biblioteca);
  await db.SaveChangesAsync();

  return Results.NoContent();
});
app.MapPut("/biblioteca/{id}", async (AppDbContext
db, Biblioteca updatebiblioteca, int id) =>
{
var biblioteca = await db.Biblioteca.FindAsync(id);
if (biblioteca is null) return
Results.NotFound();
biblioteca.Nome = updatebiblioteca.Nome;
biblioteca.inicio_funcionamento = updatebiblioteca.inicio_funcionamento;
biblioteca.fim_funcionamento = updatebiblioteca.fim_funcionamento;
biblioteca.inauguracao = updatebiblioteca.inauguracao;
biblioteca.contato = updatebiblioteca.contato;
await db.SaveChangesAsync();
return Results.NoContent();
});
app.Run();
