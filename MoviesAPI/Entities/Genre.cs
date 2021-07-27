using MoviesAPI.Controllers;
using MoviesAPI.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.Entities
{
    public class Genre //: IValidatableObject
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="The Field with name '{0}' is required")]
        [StringLength(10)]
        [FirstLetterUpperCaseAttribute]
        public string Name { get; set; }

        //  [Range(18,120)]
        //public int age { get; set; }
        //[CreditCard]
        //public string CreditCard { get; set; }
        //[Url]
        //public string Url { get; set; }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validation)
        //{
        //    if (!string.IsNullOrEmpty(Name))
        //    {
        //        var firstLetter = Name[0].ToString();
        //        if(firstLetter != firstLetter.ToUpper())
        //        {
        //            yield return new ValidationResult("First letter should be uppercase", new string[] { nameof(Name) });
        //        }
        //    }
        //}
    
    }
}
