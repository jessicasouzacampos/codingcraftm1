using CodingCraftHOMod1Ex1EF.Models.Enum;
using CodingCraftHOMod1Ex1EF.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodingCraftHOMod1Ex1EF.Models
{
    [Table("Produtos")]
    public class Produto : Entidade, IEntidadePesquisa
    {
        [Key]
        public int ProdutoId { get; set; }
        public int CategoriaId { get; set; }

        [Required]
        [StringLength(200)]
        [Index("IUQ_Produtos_Nome")]
        public String Nome { get; set; }        

        [Required]
        [DataType(DataType.Currency)]
        public decimal Valor { get; set; }

        [Required]        
        public Unidade Unidade { get; set; }

        [DisplayName("Termo de Pesquisa")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public String TermoPesquisa
        {
            get { return Nome + ", " + Valor.ToString(); }
        }

        public virtual Categoria Categoria { get; set; }        

        public virtual ICollection<ProdutoLoja> ProdutoLojas { get; set; }
    }
}