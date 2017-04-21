using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodingCraft.Cap1.Models.Entidades
{
    public class ProdutoParametrizacao :EntidadeEditavel
    {
        [Key]
        public Guid ProdutoParametrizacaoId { get; set; }
        [Required]
        [DisplayName("Quantidade para Unidade")]
        public int QuantidadeParaUnidade { get; set; }
        [Required]
        [DisplayName("Valor Unitário")]
        [DataType(DataType.Currency)]
        public Decimal ValorUnitario { get; set; }
        [ScaffoldColumn(false)]
        public Guid ProdutoId { get; set; }

        [ForeignKey("ProdutoId")]
        public virtual Produto Produto { get; set; }
    }
}