using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodingCraft.Cap1.Models.Classes
{
    public class Produto : EntidadeEditavel
    {
        [Key]
        public Guid ProdutoId { get; set; }
        [Required]
        [StringLength(200)]
        [DisplayName("Nome")]
        public String Nome { get; set; }

        public virtual ICollection<ProdutoCompra> ProdutoCompras { get; set; }
        public virtual ICollection<ProdutoParametrizacao> ProdutoParametrizacoes { get; set; }

    }
}