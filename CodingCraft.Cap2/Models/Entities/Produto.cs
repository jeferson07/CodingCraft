using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodingCraft.Cap2.Models.Entities
{
    public class Produto
    {
        [Key]
        public Guid ProdutoId { get; set; }

        [Required]
        public Guid GrupoProdutoId { get; set; }

        //[Required]
        //[StringLength(50)]
        //[DisplayName("Nome")]
        //public String Nome { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Tamanho")]
        public String Tamanho { get; set; }

        [Required]
        [DisplayName("Preço")]
        [DataType(DataType.Currency)]
        public Decimal Preco { get; set; }

        [Required]
        [DisplayName("Estoque")]
        public int Estoque { get; set; }

        [StringLength(50)]
        [DisplayName("Estilo da Gola")]
        public String EstiloGola { get; set; }


        [ForeignKey("GrupoProdutoId")]
        public virtual GrupoProduto GrupoProduto { get; set; }

        public virtual ICollection<Venda> Vendas { get; set; }
    }
}