using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodingCraft.Cap1.Models.Entidades
{
    public class ProdutoCompra : EntidadeEditavel
    {
        [Key]
        public Guid ProdutoCompraId { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Entre com u número válido")]
        [DisplayName("Quantidade de itens")]
        public int Quantidade{ get; set; }
        [Required]
        [DisplayName("Valor")]
        //[RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Valor inválido")]
        [DataType(DataType.Currency)]
        public Decimal Valor { get; set; }
        [DisplayName("Produto")]
        [Index("IUQ_ProdutoCompra_ProdutoId_CompraId", IsUnique = true, Order = 1)]
        public Guid ProdutoId { get; set; }
        [DisplayName("Compra")]
        [Index("IUQ_ProdutoCompra_ProdutoId_CompraId", IsUnique = true, Order = 2)]
        public Guid CompraId { get; set; }

        [ForeignKey("ProdutoId")]
        public virtual Produto Produto { get; set; }
        [ForeignKey("CompraId")]
        public virtual Compra Compra { get; set; }

    }
}
