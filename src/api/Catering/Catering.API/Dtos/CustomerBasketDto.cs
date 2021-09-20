using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Catering.API.Dtos
{
    public class CustomerBasketDto
    {
        [Required]
        public int  Id { get; set; }

        public List<BasketItemDto> Items { get; set; }
    }
}
