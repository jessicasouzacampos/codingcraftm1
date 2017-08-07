using AutoMapper;
using CodingCraftHOMod1Ex1EF.Models;
using CodingCraftHOMod1Ex1EF.ViewModels;

namespace CodingCraftHOMod1Ex1EF.Mappers
{
    public class ViewModelToModel : Profile
    {
        public ViewModelToModel()
        {
            CreateMap<Contato, Usuario>()
                    .AfterMap((src, dst)
                        => dst.UserName = src.Nome)
                    .AfterMap((src, dst)
                        => dst.PasswordHash = src.Password)
                    .AfterMap((src, dst)
                        => dst.PhoneNumber = src.Telefone);

             CreateMap<Contato, Pessoa>()
                    .AfterMap((src, dst)
                        => dst.UserName = src.Nome)
                    .AfterMap((src, dst)
                        => dst.PasswordHash = src.Password)
                    .AfterMap((src, dst)
                        => dst.PhoneNumber = src.Telefone);


            CreateMap<Contato, PessoaFisica>()
                   .AfterMap((src, dst)
                        => dst.UserName = src.Nome)
                    .AfterMap((src, dst)
                        => dst.PasswordHash = src.Password)
                    .AfterMap((src, dst)
                        => dst.PhoneNumber = src.Telefone)
                    .AfterMap((src, dst)
                       => dst.Cpf = src.TipoPessoa == Models.Enum.TipoPessoa.PESSOAFISICA ? src.Cpf : null);

            CreateMap<Contato, PessoaJuridica>()
                   .AfterMap((src, dst)
                        => dst.UserName = src.Nome)
                    .AfterMap((src, dst)
                        => dst.PasswordHash = src.Password)
                    .AfterMap((src, dst)
                        => dst.PhoneNumber = src.Telefone)
                    .AfterMap((src, dst)
                       => dst.Cnpj = src.TipoPessoa == Models.Enum.TipoPessoa.PESSOAJURIDICA ? src.Cnpj : null);

        }
       
    }
}