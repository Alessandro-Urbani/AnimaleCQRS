using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AnimaleCQRS.Shared.Models
{
    [Table("Cliente")]
    public partial class Cliente
    {
        public Cliente()
        {
            Animali = new HashSet<Animale>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Nome { get; set; }
        [Required]
        [StringLength(50)]
        public string Cognome { get; set; }

        [InverseProperty(nameof(Animale.IdPadroneNavigation))]
        public virtual ICollection<Animale> Animali { get; set; }
    }
}
