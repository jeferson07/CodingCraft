using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodingCraft.Cap2.Models.Entities
{
    public class Teste
    {
        [Key]
        public int MyProperty { get; set; }
        [Required]
        public String Nome { get; set; }
    }
}