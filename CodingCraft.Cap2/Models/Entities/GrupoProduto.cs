﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodingCraft.Cap2.Models.Entities
{
    public class GrupoProduto
    {
        [Key]
        public Guid GrupoProdutoId { get; set; }

        [Required]
        [StringLength(200)]
        [DisplayName("Nome")]
        public String Nome { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }

    }
}
