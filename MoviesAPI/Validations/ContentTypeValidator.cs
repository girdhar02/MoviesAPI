using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.Validations
{
    public class ContentTypeValidator: ValidationAttribute
    {
        private readonly string[] validationContentType;
        private readonly string[] imageContentType = new string[] { "image/jpeg", "image/jpg", "image/png", "image/gif" };

        public ContentTypeValidator(string[] ValidationContentType)
        {
            validationContentType = ValidationContentType;
        }

        public ContentTypeValidator(ContentTypeGroup contentTypeGroup)
        {
            switch (contentTypeGroup)
            {
                case ContentTypeGroup.Image:
                    validationContentType = imageContentType;
                    break;
                default:
                    break;
            }
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

            if (!validationContentType.Contains(formFile.ContentType))
            {
                return new ValidationResult($"Content type should be one of the followings {string.Join(", ", validationContentType)}");
            }

            return ValidationResult.Success;

        }

    }

    public enum ContentTypeGroup
    {
        Image
    }
}
