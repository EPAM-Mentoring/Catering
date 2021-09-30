using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catering.API.Dtos.Buildings
{
    public class BuildingDto
    {
        public int Id { get; set; }

        public string Street { get; set; }

        public DateTimeOffset OpensAt { get; set; }

        public DateTimeOffset CloseAt { get; set; }
    }
}
