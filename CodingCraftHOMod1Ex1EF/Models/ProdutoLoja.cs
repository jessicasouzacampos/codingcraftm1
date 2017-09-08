using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodingCraftHOMod1Ex1EF.ViewModels
{
    [Table("ProdutosLojas")]
    public class ProdutoLoja : Entidade
    {
        [Key]
        public int ProdutoLojaId { get; set; }
        // [Key, Column(Order = 1)]
        [Index("IUQ_ProdutosLojas_ProdutoId_LojaId", IsUnique = true, Order = 1)]
        public int ProdutoId { get; set; }
        // [Key, Column(Order = 2)]
        [Index("IUQ_ProdutosLojas_ProdutoId_LojaId", IsUnique = true, Order = 2)]
        public int LojaId { get; set; }

        [Required]
        public int Quantidade { get; set; }

        public virtual Produto Produto { get; set; }
        public virtual Loja Loja { get; set; }
    }
}