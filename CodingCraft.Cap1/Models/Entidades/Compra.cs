using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodingCraft.Cap1.Models.Entidades
{
    public class Compra : EntidadeEditavel
    {
        [Key]
        public Guid CompraId{ get; set; }
        [Required]
        [DisplayName("Data Compra")]
        public DateTime DataCompra{ get; set; }
        [DisplayName("Data Vencimento")]
        public DateTime DataVencimento { get; set; }
        [DisplayName("Data Pagamento")]
        public DateTime DataPagamento { get; set; }

        public Guid FornecedorId { get; set; }

        [ForeignKey("FornecedorId")]
        public virtual Fornecedor Fornecedor { get; set; }
    }
}