using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodingCraft.Cap1.Models
{
    public class UsuarioCompra : EntidadeEditavel
    {
        [Key]
        public Guid UsuarioCompraId { get; set; }
        [Required]
        [DisplayName("Quantidade")]
        public int Quantidade { get; set; }
        [Required]
        [DisplayName("Data Compra")]
        public DateTime DataCompra { get; set; }
        [DisplayName("Data Pagamento")]
        public DateTime DataPagamento { get; set; }

        public virtual ProdutoParametrizacao ProdutoParametrizacao { get; set; }
        //public virtual ApplicationUser ApplicationUser { get; set; }
    }
}