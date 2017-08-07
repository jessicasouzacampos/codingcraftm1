using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodingCraftHOMod1Ex1EF.Atributos
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]    
    public class PasswordAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null) return null;

            bool isUpper = false;
            bool isLower = false;
            bool isNumber = false;

            foreach (char c in value.ToString())
            {
                if (char.IsUpper(c)) isUpper = true;
                else if (char.IsLower(c)) isLower = true;
                else if (char.IsNumber(c)) isNumber = true;
            }


            if (isUpper && isLower && isNumber)
                return null;
            else
                return new ValidationResult("Senha inválida.");
        }

        public override string FormatErrorMessage(string name)
        {
            return name;
        }

    }
}