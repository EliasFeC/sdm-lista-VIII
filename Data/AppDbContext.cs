using Microsoft.EntityFrameworkCore;
using BibliotecaApi.Models;
namespace BibliotecaApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext (DbContextOptions options) : base(options) 
    {
    }
    public DbSet<Biblioteca> Biblioteca {get; set;} = null!;
}