using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodingCraft.Cap1.Models
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
        public Decimal Valor { get; set; }


        public virtual Produto Produto { get; set; }
        public virtual Compra Compra { get; set; }
    }
}