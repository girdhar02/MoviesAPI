﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.Validations
{
    public class FileSizeValidator: ValidationAttribute
    {
        private readonly int maxFileSizeInMbs;

        public FileSizeValidator(int MaxFileSizeInMbs)
        {
            maxFileSizeInMbs = MaxFileSizeInMbs;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            IFormFile formFile = value as IFormFile;
            
            if (formFile == null)
            {
                return ValidationResult.Success;
            }

            if(formFile.Length>maxFileSizeInMbs * 1025 * 1024)
            {
                return new ValidationResult($"File Size cannnot be bigger than {maxFileSizeInMbs} Mbs");
            }

            return ValidationResult.Success;
        }
    }
}