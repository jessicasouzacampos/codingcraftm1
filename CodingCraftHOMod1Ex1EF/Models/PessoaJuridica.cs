using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace CodingCraftHOMod1Ex1EF.Models
{
    public class PessoaJuridica : Pessoa
    {
        [Required]
        [StringLength(14)]
        [Index("IUQ_PessoasJuridicas_Cnpj")]
        public String Cnpj { get; set; }


        [DisplayName("Termo de Pesquisa")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public String TermoPesquisa
        {
            get { return UserName + ", " + Cnpj; }
        }

        public PessoaJuridica()
        {

        }

        public PessoaJuridica(String cnpj, String id, String nome, String email, String telefone) 
            : base(id, nome, email, telefone)
        {
            Cnpj = cnpj;
        }
    }
}