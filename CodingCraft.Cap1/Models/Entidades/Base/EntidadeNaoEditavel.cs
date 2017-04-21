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
        [DisplayName("Data Criação")]
        [ReadOnly(true)]
        public DateTime DataCriacao{ get; set; }
        [DisplayName("Usuário Criação")]
        [ReadOnly(true)]
        public String UsuarioCriacao { get; set; }
    }
}