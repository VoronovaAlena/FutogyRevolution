using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TrafficFramework.DataResponse
{
	public class Phase
	{
		[JsonProperty("id")]
		public long Id { get; set; }

		[JsonProperty("t_osn")]
		public int TimeMain { get; set; }

		[JsonProperty("t_min")]
		public int TimeMine { get; set; }

		[JsonProperty("t_prom")]
		public int TimeProm { get; set; }

		[JsonProperty("is_hidden")]
		public bool Hidden { get; set; }

		[JsonProperty("direction")]
		public int[] Direction { get; set; }
	}
}
