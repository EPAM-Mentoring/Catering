using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.BLL.Contracts.Reserve
{
	public class ReserveRequest
	{
	   public int BuildingId { get; set; }

	   public int NewBuildingType { get; set; } = 2;

	   public string Name { get; set; }
	}
}
