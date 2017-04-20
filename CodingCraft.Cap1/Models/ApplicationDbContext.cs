using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.ModelConfiguration.Conventions;
using CodingCraft.Cap1.Models.Classes;

namespace CodingCraft.Cap1.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.


    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }


        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Fornecedor> Fornecedors { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<ProdutoCompra> ProdutoCompras { get; set; }
        public DbSet<ProdutoParametrizacao> ProdutoParametrizacoes { get; set; }
        public DbSet<UsuarioCompra> UsuarioCompras { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder dbModelBuilder)
        {
            base.OnModelCreating(dbModelBuilder);
            dbModelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}