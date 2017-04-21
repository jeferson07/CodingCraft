using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodingCraft.Cap1.Models.Classes
{
    public class ProdutoCompra : EntidadeEditavel
    {
        [Key]
        public Guid ProdutoCompraId { get; set; }
        [Required]
        [DisplayName("Quantidade de itens")]
        public int Quantidade{ get; set; }
        [Required]
        [DisplayName("Valor")]
        [DataType(DataType.Currency)]
        public Decimal Valor { get; set; }
        [ScaffoldColumn(false)]
        [Index("IUQ_ProdutoCompra_ProdutoId_CompraId", IsUnique = true, Order = 1)]
        public Guid ProdutoId { get; set; }
        [ScaffoldColumn(false)]
        [Index("IUQ_ProdutoCompra_ProdutoId_CompraId", IsUnique = true, Order = 2)]
        public Guid CompraId { get; set; }

        [ForeignKey("ProdutoId")]
        public virtual Produto Produto { get; set; }
        [ForeignKey("CompraId")]
        public virtual Compra Compra { get; set; }

    }
}
