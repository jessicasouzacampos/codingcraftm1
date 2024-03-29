﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodingCraftHOMod1Ex1EF.Models
{
    public class Categoria : Entidade
    {
        [Key]
        public int CategoriaId { get; set; }

        [Required]
        [StringLength(100)]
        [Index("IUQ_Categorias_Nome")]
        public String Nome { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }
    }
}