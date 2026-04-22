using Microsoft.EntityFrameworkCore;
using FriendlyPetAPI.Models;

namespace FriendlyPetAPI.Data
{
    public class FriendlyPetContext : DbContext
    {
        public FriendlyPetContext(DbContextOptions<FriendlyPetContext> options)
            : base(options)
        {
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Local> Locais { get; set; }
        public DbSet<Avaliacao> Avaliacoes { get; set; }
    }
}