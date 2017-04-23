using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodingCraft.Cap1.Models.Entidades
{
    public class Compra : EntidadeEditavel, IValidatableObject
    {
        [Key]
        public Guid CompraId{ get; set; }
        [Required]
        [DisplayName("Data Compra")]
        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy", ApplyFormatInEditMode = true)]
        public DateTime DataCompra{ get; set; }
        [DisplayName("Data Vencimento")]
        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy", ApplyFormatInEditMode = true)]
        public DateTime DataVencimento { get; set; }
        [DisplayName("Data Pagamento")]
        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy", ApplyFormatInEditMode = true)]
        public DateTime DataPagamento { get; set; }
        [DisplayName("Fornecedor")]
        public Guid FornecedorId { get; set; }
        [DisplayName("Fornecedor")]
        [ForeignKey("FornecedorId")]
        public virtual Fornecedor Fornecedor { get; set; }
        [DisplayName("Produto")]
        public virtual ICollection<ProdutoCompra> ProdutoCompras { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ProdutoCompras == null || ProdutoCompras.Count == 0)
            {
                yield return new ValidationResult("Uma compra deve possuir pelo menos um produto selecionado", new string[] { "ProdutoCompras" });
            }
            else if (ProdutoCompras.GroupBy(pc => pc.ProdutoId).Where(g => g.Count() > 1).Count() > 0)
            {
                yield return new ValidationResult("Um produto só pode ser selecionado uma vez por compra", new string[] { "ProdutoCompras" });
            }
        }
    }
}