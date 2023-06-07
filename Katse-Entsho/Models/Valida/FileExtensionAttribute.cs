using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Katse_Entsho.Models.Valida
{
    public class FileExtensionAttribute:ValidationAttribute
    {
        //Creating custom validation for IFormFile to accept onl jpg and png file extenion
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            //Assigning object value to IFormFIle
            var file = value as IFormFile;

            if (file != null)
            {
                var extension = Path.GetExtension(file.FileName);
                string[] allowedExtensions = { "jpg", "png" };

                bool result = allowedExtensions.Any(x => extension.EndsWith(x));

                if (!result)
                {
                    return new ValidationResult(GetErrorMessage());
                }

               
            }

            return ValidationResult.Success;
        }

        private string GetErrorMessage()
        {
            return "allowed extensions are jpg and png";
        }
    }
}
