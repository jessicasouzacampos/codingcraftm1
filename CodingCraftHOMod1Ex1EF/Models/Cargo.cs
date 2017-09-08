using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodingCraftHOMod1Ex1EF.Models
{
    public class Cargo : Entidade
    {
        public Cargo()
        {

        }

        public Cargo(string nome)
        {
            Nome = nome;
        }

        [Key]
        public int CargoId { get; set; }

        [Required]
        [StringLength(100)]
        [Index("IUQ_Cargos_Nome")]        
        public String Nome { get; set; }
    }
}