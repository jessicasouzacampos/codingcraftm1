﻿using CodingCraftHOMod1Ex1EF.Models;
using System;
using System.Reflection;

namespace CodingCraftHOMod1Ex1EF.Extensions
{
    public static class SalvaPesquisaHelperExtensions
    {

        public static void Salva<T>(Object objeto, string userId) where T : class
        {
            PesquisaSalva pesquisa = new PesquisaSalva();
            PropertyInfo[] propertyInfo = objeto.GetType().GetProperties();

            foreach (var item in propertyInfo)
            {                
                if(item.GetValue(objeto, null) != null)
                {
                    pesquisa.Filtros += item.Name +";";
                    pesquisa.Pesquisa += item.GetValue(objeto, null).ToString() + ";";
                }               
            }

            if (!string.IsNullOrEmpty(pesquisa.Filtros) && !string.IsNullOrEmpty(pesquisa.Pesquisa))
            {
                using (var ctx = new ApplicationDbContext())
                {
                    pesquisa.DataHoraPesquisa = DateTime.Now;
                    pesquisa.UsuarioId = new Guid(userId);
                    ctx.Pesquisas.Add(pesquisa);
                    ctx.SaveChanges();
                }
            }
            
        }
    }
}