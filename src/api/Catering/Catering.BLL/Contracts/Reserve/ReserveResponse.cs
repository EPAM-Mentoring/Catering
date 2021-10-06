using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.BLL.Contracts.Reserve
{
	 public class ReserveResponse
     {
		public int Id { get; set; }
		public string Name { get; set; }
		public int BuildingType { get; set; }
	    public int BuildingStatus { get; set; }
		public DateTimeOffset OpensAt { get; set; }
		public DateTimeOffset CloseAt { get; set; }
		public int FloorCount { get; set; }
		public int FlatCount { get; set; }
		public string Street { get; set; }
		public int Number { get; set; }
	}

	public class TimeSpanCustom
	{
		public int Ticks { get; set; }

		public int Days { get; set; }

		public int Hours { get; set; }

		public int Milliseconds { get; set; }

		public int Minutes { get; set; }

		public int Seconds { get; set; }

		public int TotalDays { get; set; }

		public int TotalMilliseconds { get; set; }

		public int TotalMinutes { get; set; }
       
		public int TotalSeconds { get; set; }
	}
}