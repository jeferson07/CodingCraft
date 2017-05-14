using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodingCraft.Cap2.Models.Entities
{
    public class Venda
    {
        [Key]
        public Guid VendaId { get; set; }

        public Guid GrupoProdutoId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Entre com um número válido e superior a 0")]
        [DisplayName("Quantidade de itens")]
        public int Quantidade { get; set; }

        [ForeignKey("GrupoProdutoId")]
        public virtual GrupoProduto GrupoProduto { get; set; }

    }
}
