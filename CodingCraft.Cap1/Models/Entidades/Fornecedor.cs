using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodingCraft.Cap1.Models.Entidades
{
    public class Fornecedor : EntidadeEditavel
    {
        [Key]
        public Guid FornecedorId { get; set; }
        [Required]
        [StringLength(200)]
        [DisplayName("Nome")]
        public String Nome { get; set; }

        public virtual ICollection<Compra> Compras { get; set; }

    }
}