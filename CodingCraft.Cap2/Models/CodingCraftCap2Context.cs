using CodingCraft.Cap2.Models.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace CodingCraft.Cap2.Models
{
    public class CodingCraftCap2Context : IdentityDbContext<ApplicationUser>
    {
        public CodingCraftCap2Context()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<GrupoProduto> GruposProdutos { get; set; }
        public DbSet<Venda> Vendas { get; set; }


        public static CodingCraftCap2Context Create()
        {
            return new CodingCraftCap2Context();
        }

        protected override void OnModelCreating(DbModelBuilder dbModelBuilder)
        {
            base.OnModelCreating(dbModelBuilder);
            dbModelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}