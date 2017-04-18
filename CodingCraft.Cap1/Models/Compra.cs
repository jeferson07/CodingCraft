using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodingCraft.Cap1.Models
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

        public virtual Fornecedor Fornecedor { get; set; }
    }
}