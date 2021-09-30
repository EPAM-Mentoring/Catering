using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Catering.API.Dtos
{
    public abstract class FoodManipulateDto
    {
        [Required(ErrorMessage = "You should fill out a name")]
        [MaxLength(50, ErrorMessage = "The name shouldn't have more than 50 characters.")]
        public string FoodName { get; set; }

        [Required(ErrorMessage = "You should fill out a description.")]
        [MaxLength(1500, ErrorMessage = "The description shouldn't have more than 1500 characters.")]
        public virtual string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string PictureUrl { get; set; }
    }
}
