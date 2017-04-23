using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodingCraft.Cap1.Models.Entidades
{
    public class Produto : EntidadeEditavel
    {
        [Key]
        public Guid ProdutoId { get; set; }
        [Required]
        [StringLength(200)]
        [DisplayName("Nome")]
        public String Nome { get; set; }
        [Required]
        [DisplayName("Quantidade para Unidade")]
        public int QuantidadeParaUnidade { get; set; }
        [Required]
        [DisplayName("Valor Unitário")]
        [DataType(DataType.Currency)]
        public Decimal ValorUnitario { get; set; }

        public virtual ICollection<ProdutoCompra> ProdutoCompras { get; set; }
        public virtual ICollection<UsuarioCompra> UsuarioCompras { get; set; }

    }
}