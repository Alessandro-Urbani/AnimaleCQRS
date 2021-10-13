using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AnimaleCQRS.Shared.Models
{
    [Table("Animale")]
    public partial class Animale
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Nome { get; set; }
        [Required]
        [StringLength(50)]
        public string Razza { get; set; }
        [Required]
        [StringLength(50)]
        public string Sesso { get; set; }
        public int IdPadrone { get; set; }

        [ForeignKey(nameof(IdPadrone))]
        [InverseProperty(nameof(Cliente.Animali))]
        public virtual Cliente IdPadroneNavigation { get; set; }
    }
}
