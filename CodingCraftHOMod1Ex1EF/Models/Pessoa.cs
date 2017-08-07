using CodingCraftHOMod1Ex1EF.Models.Interfaces;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodingCraftHOMod1Ex1EF.Models
{
    public class Pessoa : Usuario, IEntidade
    {
        public virtual Cliente Cliente { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }

        public DateTime? DataUltimaModificacao { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string UsuarioUltimaModificacao { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime DataCriacao { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string UsuarioCriacao { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        //[DisplayName("Termo de Pesquisa")]
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        //public String TermoPesquisa
        //{
        //    get { return UserName + ", " + Email; }
        //    private set { }
        //}

    }
}