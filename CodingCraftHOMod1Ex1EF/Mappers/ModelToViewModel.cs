using AutoMapper;
using CodingCraftHOMod1Ex1EF.Models;
using CodingCraftHOMod1Ex1EF.ViewModels;

namespace CodingCraftHOMod1Ex1EF.Mappers
{
    public class ModelToViewModel : Profile
    {
        public ModelToViewModel()
        {
            CreateMap<Usuario, Contato>()
                    .AfterMap((src, dst)
                        => dst.Nome = src.UserName)
                    .AfterMap((src, dst)
                        => dst.Password = src.PasswordHash)
                    .AfterMap((src, dst)
                        => dst.Telefone = src.PhoneNumber);

             CreateMap<Pessoa, Contato>()
                    .AfterMap((src, dst)
                        => dst.Nome = src.UserName)
                    .AfterMap((src, dst)
                        => dst.Password = src.PasswordHash)
                    .AfterMap((src, dst)
                        => dst.Telefone = src.PhoneNumber);

            CreateMap<PessoaFisica, Contato>()
                   .AfterMap((src, dst)
                       => dst.Nome = src.UserName)
                   .AfterMap((src, dst)
                       => dst.Password = src.PasswordHash)
                   .AfterMap((src, dst)
                       => dst.Telefone = src.PhoneNumber)
                    .AfterMap((src, dst)
                       => dst.TipoPessoa = Models.Enum.TipoPessoa.PESSOAFISICA);

            CreateMap<PessoaJuridica, Contato>()
                   .AfterMap((src, dst)
                       => dst.Nome = src.UserName)
                   .AfterMap((src, dst)
                       => dst.Password = src.PasswordHash)
                   .AfterMap((src, dst)
                       => dst.Telefone = src.PhoneNumber)
                    .AfterMap((src, dst)
                       => dst.TipoPessoa = Models.Enum.TipoPessoa.PESSOAJURIDICA);

        }
       
    }
}