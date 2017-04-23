using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodingCraft.Cap1.Models.Entidades
{
    public class UsuarioCompra : EntidadeEditavel
    {
        [Key]
        public Guid UsuarioCompraId { get; set; }
        [Required]
        [DisplayName("Unidade")]
        public int Unidade { get; set; }
        [Required]
        [DisplayName("Data Compra")]
        public DateTime DataCompra { get; set; }
        [DisplayName("Data Pagamento")]
        public DateTime DataPagamento { get; set; }
        [DisplayName("Produto")]
        public Guid ProdutoId { get; set; }
        [Required]
        [DisplayName("Valor Unitário")]
        [DataType(DataType.Currency)]
        public Decimal ValorUnitario { get; set; }

        [ForeignKey("ProdutoId")]
        public virtual Produto Produto { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}