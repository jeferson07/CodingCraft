using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodingCraft.Cap2.Models.Entities
{
    public class Tag
    {
        [Key]
        public Guid TagId { get; set; }

        [Required]
        [StringLength(200)]
        [DisplayName("Nome")]
        public String Nome { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

    }
}