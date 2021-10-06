using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catering.API.Dtos.Buildings
{
	public class BuildingDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int BuildingType { get; set; }
		public int BuildingStatus { get; set; }
		public TimeSpan OpensAt { get; set; }
		public TimeSpan CloseAt { get; set; }
		public int FloorCount { get; set; }
		public int FlatCount { get; set; }
		public string Street { get; set; }
		public int Number { get; set; }
	}
}
