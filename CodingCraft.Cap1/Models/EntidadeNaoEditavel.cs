using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodingCraft.Cap1.Models
{
    public abstract class EntidadeNaoEditavel
    {
        [Required]
        [DisplayName("Data Criação")]
        public DateTime DataCriacao{ get; set; }
        [Required]
        [DisplayName("Usuário Criação")]
        public String UsuarioCriacao { get; set; }
    }
}