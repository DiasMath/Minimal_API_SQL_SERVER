using Microsoft.EntityFrameworkCore;
using Minimal_API_SQL_SERVER.Models;

namespace Minimal_API_SQL_SERVER.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    public DbSet<Livro> Livros { get; set; }

}
