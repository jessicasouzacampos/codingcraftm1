using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace CodingCraftHOMod1Ex1EF.Models
{
    public class PessoaFisica : Pessoa
    {
        [Required]
        [StringLength(14)]
        [Index("IUQ_PessoasFisicas_Cpf")]
        public String Cpf { get; set; }

        [DisplayName("Termo de Pesquisa")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public String TermoPesquisa
        {
            get { return UserName + ", " + Cpf; }
        }

        public PessoaFisica()
        {

        }

        public PessoaFisica(String cpf, String id, String nome, String email, String telefone) 
            : base(id, nome, email, telefone)
        {
            Cpf = cpf;
        }
    }
}