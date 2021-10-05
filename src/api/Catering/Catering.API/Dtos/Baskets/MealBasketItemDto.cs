using System.ComponentModel.DataAnnotations;

namespace Catering.API.Dtos
{
    public class MealBasketItemDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string MealName { get; set; }

        [Required]
        [Range(0.1, double.MaxValue, ErrorMessage = "Price must be greater than zero")]
        public decimal MealPrice { get; set; }

        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Quantity must be at least 1")]
        public int MealQuantity { get; set; }

        [Required]
        public string MealPictureUrl { get; set; }
    }
}