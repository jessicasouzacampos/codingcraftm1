using System;
using System.ComponentModel.DataAnnotations;

namespace CodingCraftHOMod1Ex1EF.Models.ControleUsuarios
{
    public class UsuarioEndereco
    {
        [Key]
        public Guid UsuarioEnderecoId { get; set; }
        public Guid UsuarioId { get; set; }

        [Required]
        public string Logradouro { get; set; }
        [Required]
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}