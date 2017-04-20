using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodingCraft.Cap1.Models.Classes
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
        [ScaffoldColumn(false)]
        public Guid ProdutoParametrizacaoId { get; set; }

        [ForeignKey("ProdutoParametrizacaoId")]
        public virtual ProdutoParametrizacao ProdutoParametrizacao { get; set; }
        //public virtual ApplicationUser ApplicationUser { get; set; }
    }
}