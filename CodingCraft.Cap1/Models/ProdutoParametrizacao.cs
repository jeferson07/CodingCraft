using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodingCraft.Cap1.Models
{
    public class ProdutoParametrizacao :EntidadeEditavel
    {
        [Key]
        public Guid ProdutoParametrizacaoId { get; set; }
        [Required]
        [DisplayName("Quantidade")]
        public int Quantidade { get; set; }
        [Required]
        [DisplayName("Valor Unitário")]
        public Decimal ValorUnitario { get; set; }
        [DisplayName("Data Inicial")]
        public DateTime DataInicio { get; set; }
        [DisplayName("Data Final")]
        public DateTime DataFim { get; set; }


        public virtual Produto Produto { get; set; }
    }
}