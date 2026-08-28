using Microsoft.EntityFrameworkCore;
using SistemaEstoque.Models;

namespace SistemaEstoque.Context
{
    public class PerfilsContext : DbContext
    {
        public PerfilsContext(DbContextOptions<PerfilsContext> options) : base(options)
        {
            
        }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
