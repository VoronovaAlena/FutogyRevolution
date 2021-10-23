using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficFramework.Data
{
	public class PhasePart
	{
		public long Id { get; set; }

		public DateTime TimeStart { get; set; }

		public DateTime TimeEnd { get; set; }

		public TimeSpan TimeInterval => (TimeEnd - TimeStart);
	}
}
