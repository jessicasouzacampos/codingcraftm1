using Newtonsoft.Json;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace CodingCraftHOMod1Ex1EF.Extensions
{
    public static class ArquivosHelperExtensions
    {
        public static String SalvarExcel<T>(string nomePlanilha, List<T> Objetos) where T : class
        {
            using (var excelPackage = new ExcelPackage())
            {               
                excelPackage.Workbook.Properties.Author = "Jessica";
                excelPackage.Workbook.Properties.Title = "Meu Excel";

                var sheet = excelPackage.Workbook.Worksheets.Add(nomePlanilha);
                sheet.Name = nomePlanilha;           

                Type type = typeof(T);

                var a = 1;
                
                PropertyInfo[] propertyInfo = Objetos.First().GetType().GetProperties();
                
                foreach (var pInfo in propertyInfo)
                {
                    sheet.Cells[1, a++].Value = pInfo.Name;
                }

                var linha = 2;
                var coluna = 1;
                for (int i = 0; i < Objetos.Count(); i++)
                {                   
                    foreach (var pInfo in propertyInfo)
                    {                       
                        sheet.Cells[linha, coluna++].Value = pInfo.GetValue(Objetos[i], null);
                    }
                    linha++;
                    coluna = 1;                   
                }

                string path = @"D:\"+ nomePlanilha + ".xlsx";
                File.WriteAllBytes(path, excelPackage.GetAsByteArray());
                
                return path;
            }
        }

        public static String SalvarJson<T>(List<T> Objetos, string nomeArquivo) where T : class
        {           
            var json = JsonConvert.SerializeObject(new
            {
                o = Objetos
            });

            string path = @"D:\" + nomeArquivo + ".json";
            File.WriteAllText(path, json);

            return path;
        }

        public static String SalvarXML<T>(List<T> Objetos, string elementName, string nomeArquivo) where T : class
        {
            XElement element = GetXElements(Objetos, elementName);

            string path = @"D:\" + nomeArquivo + ".xml";   
            element.Save(path);

            return path;
        }

        private static XElement GetXElements<T>(IEnumerable<T> collection, string elementName) where T : class
        {
            return new XElement(elementName, collection.Select(GetXElement));
        }

        private static XElement GetXElement<T>(T item)
        {
            return new XElement(typeof(T).Name,
                typeof(T).GetProperties()
                         .Select(prop => new XElement(prop.Name, prop.GetValue(item, null))));
        }

        
    }
}