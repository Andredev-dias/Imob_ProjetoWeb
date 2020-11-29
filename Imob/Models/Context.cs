using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Imob.Models
{
    public class Context : IdentityDbContext<Usuario>
    {
        public Context(DbContextOptions options) : base(options) { }
        public DbSet<Corretor> Corretores { get; set; }
        public DbSet<Contrato> Contratos { get; set; }
        public DbSet<Imovel> Imoveis { get; set; }
        public DbSet<Locatario> Locatarios { get; set; }
        public DbSet<TipoImovel> TipoImovel { get; set; }
        public DbSet<UsuarioLogado> UsuarioLogado { get; set; }
    }
}
