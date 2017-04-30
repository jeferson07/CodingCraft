using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodingCraft.Cap1.Models
{
    public abstract class EntidadeEditavel : EntidadeNaoEditavel
    {
        [DisplayName("Data Modificaçao")]
        [ReadOnly(true)]
        public DateTime? DataModificacao { get; set; }
        [DisplayName("Usuário Modificaçao")]
        [ReadOnly(true)]
        public String UsuarioModificacao { get; set; }
    }
}