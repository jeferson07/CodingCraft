using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.ModelConfiguration.Conventions;
using CodingCraft.Cap1.Models.Entidades;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System;
using System.Linq;
using System.Web;
using System.Data.Entity.Validation;

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
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<ProdutoCompra> ProdutoCompras { get; set; }
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

        public override int SaveChanges()
        {
            try
            {
                CheckEntities(ChangeTracker.Entries());
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var errorMessages = ex.EntityValidationErrors
                    .SelectMany(x => x.ValidationErrors)
                    .Select(x => x.ErrorMessage);

                var fullErrorMessage = string.Join(";", errorMessages);

                var excpetionsMessage = string.Concat(ex.Message, "Os erros de validações são: ", fullErrorMessage);

                throw new DbEntityValidationException(excpetionsMessage, ex.EntityValidationErrors);
            }            
        }

        public override Task<int> SaveChangesAsync()
        {
            try
            {
                CheckEntities(ChangeTracker.Entries());
                return base.SaveChangesAsync();
            }
            catch (DbEntityValidationException ex)
            {
                var errorMessages = ex.EntityValidationErrors
                    .SelectMany(x => x.ValidationErrors)
                    .Select(x => x.ErrorMessage);

                var fullErrorMessage = string.Join(";", errorMessages);

                var excpetionsMessage = string.Concat(ex.Message, "Os erros de validações são: ", fullErrorMessage);

                throw new DbEntityValidationException(excpetionsMessage, ex.EntityValidationErrors);
            }
        }

        private void CheckEntities(IEnumerable<DbEntityEntry> entires)
        {
            var dataAtual = DateTime.Now;

            foreach (var entry in entires.Where(e => e.Entity != null &&
                        typeof(EntidadeNaoEditavel).IsAssignableFrom(e.Entity.GetType())))
            {
                if (entry.State == EntityState.Added)
                {
                    if (entry.Property("DataCriacao") != null)
                    {
                        entry.Property("DataCriacao").CurrentValue = dataAtual;
                    }
                    if (entry.Property("UsuarioCriacao") != null)
                    {
                        entry.Property("UsuarioCriacao").CurrentValue = HttpContext.Current != null ? HttpContext.Current.User.Identity.Name : "Usuario" ;
                    }
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCriacao").IsModified = false;
                    entry.Property("UsuarioCriacao").IsModified = false;

                    if (entry.Property("DataModificacao") != null)
                    {
                        entry.Property("DataModificacao").CurrentValue = dataAtual;
                    }
                    if (entry.Property("UsuarioModificacao") != null)
                    {
                        entry.Property("UsuarioModificacao").CurrentValue = HttpContext.Current != null ? HttpContext.Current.User.Identity.Name : "Usuario";
                    }
                }
            }
        }
    }

}